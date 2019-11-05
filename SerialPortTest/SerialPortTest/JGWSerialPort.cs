using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.IO.Ports;
using System.Windows.Forms;
using System.Threading;
using System.Text.RegularExpressions;
using SerialPortTest;

namespace GongNiu.Common
{
    public partial class JGWSerialPort : SerialPort
    {
        private bool Closing = false;
        public JGWSerialPort()
        {
            InitializeComponent();
            this.DataReceived += new SerialDataReceivedEventHandler(MyDataReceived);
        }

        public JGWSerialPort(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            this.DataReceived += new SerialDataReceivedEventHandler(MyDataReceived);
        }

        #region 监听针脚
        public delegate void ListenDelegate(bool DSRFlag, bool CDFlag, bool CTSFlag);
        public ListenDelegate ListenHandle;
        #endregion

        #region 控制针脚
        public int ContinuedTime = 100;
        Thread ContinuedThread = null;
        PinType pinType = PinType.Dtr;
        bool pinValue = true;
        bool continueding = false;
        public void ContinuedFun()
        {
            while (true)
            {
                try
                {
                    if (Closing)
                        break;
                    continueding = true;
                    if (IsOpen)
                    {
                        if (pinType == PinType.Dtr)
                        {
                            DtrEnable = pinValue;
                        }
                        else if (pinType == PinType.Rts)
                        {
                            RtsEnable = pinValue;
                        }
                        System.Threading.Thread.Sleep(ContinuedTime);
                        if (pinType == PinType.Dtr)
                        {
                            DtrEnable = !pinValue;
                        }
                        else if (pinType == PinType.Rts)
                        {
                            RtsEnable = !pinValue;
                        }
                    }
                    continueding = false;
                    ContinuedThread.Suspend();
                }
                catch (Exception ex)
                {
                    if (IsOpen)
                        Close();
                }
            }
        }

        public void SetDtrEnable(bool value)
        {
            if (continueding)
                return;
            pinType = PinType.Dtr;
            pinValue = value;
            if (ContinuedThread == null || ContinuedThread.ThreadState == System.Threading.ThreadState.Stopped)
            {
                ContinuedThread = new Thread(ContinuedFun);
                ContinuedThread.Start();
            }
            else if (ContinuedThread.ThreadState == System.Threading.ThreadState.Suspended)
            {
                ContinuedThread.Resume();
            }
        }

        public void SetRtsEnable(bool value)
        {
            if (continueding)
                return;
            pinType = PinType.Rts;
            pinValue = value;
            if (ContinuedThread == null || ContinuedThread.ThreadState == System.Threading.ThreadState.Stopped)
            {
                ContinuedThread = new Thread(ContinuedFun);
                ContinuedThread.Start();
            }
            else if (ContinuedThread.ThreadState == System.Threading.ThreadState.Suspended)
            {
                ContinuedThread.Resume();
            }
        }
        #endregion

        #region 接收指令
        public string beginFlag = "$";
        public string endFlag = "$";
        //private bool Listening = false;
        public byte[] binaryData = new byte[1024];
        public delegate bool DelegateAnalyzeMethod(byte[] per);
        public delegate void DelegateDealMethod(object[] per);
        public DelegateAnalyzeMethod AnalyzeMethod = null;
        public DelegateDealMethod DealMethod = null;
        List<byte> buffer = new List<byte>(4096);
        Stopwatch time = new Stopwatch();
        void MyDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            #region //精简版本注释)
            //if (Closing) return;
            //try
            //{
            //    time.Restart();
            //    //Thread.Sleep(GeneralData.recvDelay);
            //    string strRecv = string.Empty;
            //    //Listening = true;
            //    int n = BytesToRead;
            //    byte[] buf = new byte[n];
            //    Read(buf, 0, n);

            //    bool data_1_catched = false;
            //    if (AnalyzeMethod != null)
            //    {
            //        data_1_catched = AnalyzeMethod(buf);
            //    }
            //    else
            //    {
            //        strRecv = Encoding.Default.GetString(buf);
            //        data_1_catched = true;
            //    }
            //    //分析数据
            //    if (data_1_catched)
            //    {
            //        string[] aa = { strRecv };

            //        if (DealMethod != null)
            //            DealMethod(aa);
            //    }
            //    time.Stop();
            //    MessageBox.Show(time.Elapsed.TotalMilliseconds.ToString());
            //    //else
            //    //{
            //    //    //Log.Write("\n接收异常：" + strRecv + "|" + DateTime.Now.ToString());
            //    //}
            //}
            //catch (Exception ex)
            //{
            //    Log.WriteHttpPost(ex.Message, "串口接收函数异常");
            //}
            //finally
            //{
            //    //Listening = false;
            //}
            #endregion

            #region //验证接收数据完整型
            if (Closing) return;
            try
            {
                int n = BytesToRead;
                byte[] buf = new byte[n];
                Read(buf, 0, n);

                bool data_1_catched = false;
                string strRecv = Encoding.Default.GetString(buf);
                buffer.AddRange(buf);
                while (true)
                {
                    if (strRecv.IndexOf(endFlag) < 0)
                        break;
                    else
                    {
                        strRecv = Encoding.Default.GetString(buffer.ToArray());
                        if (strRecv.IndexOf(beginFlag) == 0)
                        {
                            data_1_catched = true;
                            buffer.Clear();
                            break;
                        }
                        else
                        {
                            buffer.Clear();
                            Log.WriteHttpPost($"扫码数据起始符异常:{strRecv}", $"{this.PortName}扫码通讯异常");
                            break;
                        }
                    }
                }
                //分析数据
                if (data_1_catched)
                {
                    string[] aa = { strRecv };
                    DealMethod?.Invoke(aa);
                }
            }
            catch (Exception ex)
            {
                Log.WriteHttpPost(ex.Message, "串口接收函数异常");
            }
            #endregion
        }

        private string GetCode(string text)
        {
            int pos1 = text.IndexOf(beginFlag);
            int pos2 = text.IndexOf(endFlag);
            if (pos1 >= 0 && pos2 >= 0)
            {
                text = text.Substring(0, pos2);
            }

            return string.IsNullOrEmpty(beginFlag) ? text : text.Replace(beginFlag, "");
        }
        #endregion

        #region 发送指令
        public void SendText(string text)
        {
            if (IsOpen)
            {
                Byte[] command = new System.Text.ASCIIEncoding().GetBytes(text);
                Write(command, 0, command.Length);
            }
        }
        #endregion

        /// <summary>
        /// 初始化串口
        /// </summary>
        public void Open()
        {
            if (!IsOpen)
            {
                Closing = false;
                base.Open();
            }
        }

        /// <summary>
        /// 关闭串口
        /// </summary>
        public new void Close()
        {
            if (IsOpen)
            {
                Closing = true;
                base.Close();
            }
        }
    }

    public enum PinType
    {
        Rts,
        Dtr
    }
}
