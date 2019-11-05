using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialPortTest
{
    public partial class FrmMain : Form
    {

        SerialCOM device01;
        SerialCOM device02;
        SerialCOM plc;
        Barrier _barrier = new Barrier(2);
        int timeOut = 0;

        byte[] byteOK = null;
        byte[] byteNG = null;
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            List<string> comList = GetLocalCOM();
            foreach (string com in comList)
            {
                CbxDevice01_COM.Items.Add(com);
                CbxDevice02_COM.Items.Add(com);
                CbxPLC_COM.Items.Add(com);
            }
            GetControlText(gbx_Device01);
            GetControlText(gbx_Device02);
            GetControlText(gbx_PLC);

            this.ChBox_Enable.Checked = string.IsNullOrEmpty(AppConfig.GetItemValue("PLC_Enabled")) ?
                false : Convert.ToBoolean(AppConfig.GetItemValue("PLC_Enabled"));
            this.Numeric.Value = string.IsNullOrEmpty(AppConfig.GetItemValue("TimeOut")) ?
                1000 : Convert.ToInt32(AppConfig.GetItemValue("TimeOut"));
        }

        /// <summary>
        /// 获取本地串口
        /// </summary>
        /// <returns></returns>
        public static List<string> GetLocalCOM()
        {
            string[] listCOM = SerialPort.GetPortNames();
            return listCOM.ToList<string>();
        }

        /// <summary>
        /// 保存控件填写的信息
        /// </summary>
        /// <param name="control"></param>
        private void SaveControlInfo(object control)
        {
            Control container = control as Control;
            string name = container.Name;
            name = name.Substring(name.IndexOf("_") + 1);
            foreach (Control c in container.Controls)
            {
                if (c.GetType() == typeof(ComboBox) || c.GetType() == typeof(TextBox))
                {
                    AppConfig.SetItemValue($"{name}_{c.Name.Substring(c.Name.IndexOf("_") + 1)}", c.Text.Trim());
                }
            }
        }

        /// <summary>
        /// 获取Appconfig.xml中的参数并赋给对应的控件
        /// </summary>
        /// <param name="control"></param>
        private void GetControlText(object control)
        {
            Control container = control as Control;
            string name = container.Name;
            name = name.Substring(name.IndexOf("_") + 1);
            foreach (Control c in container.Controls)
            {
                if (c is TextBox || c is ComboBox)
                {
                    c.Text = AppConfig.GetItemValue($"{name}_{c.Name.Substring(c.Name.IndexOf("_") + 1)}");
                }
            }
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            byteOK = StrToHexByte(AppConfig.GetItemValue("OrderOK"));
            byteNG = StrToHexByte(AppConfig.GetItemValue("OrderNG"));
            BtnOpen.Enabled = false;
            timeOut = Convert.ToInt32(Numeric.Value);
            SaveControlInfo(gbx_Device01);
            SaveControlInfo(gbx_Device02);
            SaveControlInfo(gbx_PLC);
            if (ChBox_Enable.Checked)
                AppConfig.SetItemValue("PLC_Enabled", "true");
            else
                AppConfig.SetItemValue("PLC_Enabled", "false");
            AppConfig.SetItemValue("TimeOut", Numeric.Value.ToString());

            InitDevice01(out device01);
            if (!device01.Start())
            {
                device01.Stop();
                LabelDevice01.Text = "设备1连接失败";
                LabelDevice01.ForeColor = Color.Red;
                Message.Warning("设备1初始化失败");
                BtnOpen.Enabled = true;
                return;
            }
            else
            {
                LabelDevice01.Text = "设备1连接成功";
                LabelDevice01.ForeColor = Color.Green;
                BtnOpen.Enabled = false;
            }
            InitDevice02(out device02);
            if (!device02.Start())
            {
                device02.Stop();
                LabelDevice02.Text = "设备2连接失败";
                LabelDevice02.ForeColor = Color.Red;
                Message.Warning("设备2初始化失败");
                return;
            }
            else
            {
                LabelDevice02.Text = "设备2连接成功";
                LabelDevice02.ForeColor = Color.Green;
            }
            if (ChBox_Enable.Checked)
            {
                InitPLC(out plc);
                if (!plc.Start())
                {
                    plc.Stop();
                    LabelPLC.Text = "PLC连接失败";
                    LabelPLC.ForeColor = Color.Red;
                    Message.Warning("PLC初始化失败");
                    return;
                }
                else
                {
                    LabelPLC.Text = "PLC连接成功";
                    LabelPLC.ForeColor = Color.Green;
                }
            }
            else
            {
                LabelPLC.Text = "PLC未启用";
                LabelPLC.ForeColor = Color.Black;
            }

            Numeric.Enabled = false;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            if (device01 != null && device01.IsOpen())
            {
                device01.Stop();
                LabelDevice01.Text = "设备1已关闭";
                LabelDevice01.ForeColor = Color.Black;
            }
            if (device02 != null && device02.IsOpen())
            {
                device02.Stop();
                LabelDevice02.Text = "设备2已关闭";
                LabelDevice02.ForeColor = Color.Black;
            }
            if (plc != null && plc.IsOpen())
            {
                plc.Stop();
                LabelPLC.Text = "PLC已关闭";
                LabelPLC.ForeColor = Color.Black;
            }
            BtnOpen.Enabled = true;
            Numeric.Enabled = true;
        }

        private void InitDevice01(out SerialCOM serialCOM)
        {
            serialCOM = new SerialCOM
            {
                ComName = AppConfig.GetItemValue("Device01_COM"),
                BaudRate = string.IsNullOrEmpty(AppConfig.GetItemValue("Device01_Baud")) ? 9600 : Convert.ToInt32(AppConfig.GetItemValue("Device01_Baud")),
                strStart = AppConfig.GetItemValue("Device01_BeginFlag"),
                strEnd = AppConfig.GetItemValue("Device01_EndFlag"),
                DealMethod = new BaseScan.DelegateDealMethod(DealDevice01)
            };
        }

        private void InitDevice02(out SerialCOM serialCOM)
        {
            serialCOM = new SerialCOM
            {
                ComName = AppConfig.GetItemValue("Device02_COM"),
                BaudRate = string.IsNullOrEmpty(AppConfig.GetItemValue("Device02_Baud")) ? 9600 : Convert.ToInt32(AppConfig.GetItemValue("Device02_Baud")),
                strStart = AppConfig.GetItemValue("Device02_BeginFlag"),
                strEnd = AppConfig.GetItemValue("Device02_EndFlag"),
                DealMethod = new BaseScan.DelegateDealMethod(DealDevice02)
            };
        }

        private void InitPLC(out SerialCOM serialCOM)
        {
            serialCOM = new SerialCOM
            {
                ComName = AppConfig.GetItemValue("PLC_COM"),
                BaudRate = string.IsNullOrEmpty(AppConfig.GetItemValue("PLC_Baud")) ? 
                9600 : Convert.ToInt32(AppConfig.GetItemValue("PLC_Baud"))
            };
        }

        private void DealDevice01(string data)
        {
            data = Dealcode(data, device01);
            this.Invoke((EventHandler)delegate
            {
                Device01Data.Text = data;
            });
            if (!_barrier.SignalAndWait(timeOut))
            {
                if(plc != null && plc.IsOpen())
                    plc.Send(byteNG);
                this.Invoke((EventHandler)delegate
                {
                    LabelStatus.Text = "NG";
                    LabelStatus.ForeColor = Color.Red;
                    LabelMessage.Text = "(数据2超时)";
                });
                return;
            }
            this.Invoke((EventHandler)delegate
            {
                ListViewItem listDevice01 = new ListViewItem();
                listDevice01.SubItems.Add($"{LvDevice01.Items.Count + 1}");
                listDevice01.SubItems.Add(data);
                LvDevice01.Items.Insert(0, listDevice01);
            });
        }

        private void DealDevice02(string data)
        {
            data = Dealcode(data, device01);
            this.Invoke((EventHandler)delegate
            {
                Device02Data.Text = data;
            });
            if (!_barrier.SignalAndWait(timeOut))
            {
                if (plc != null && plc.IsOpen())
                    plc.Send(byteNG);
                this.Invoke((EventHandler)delegate
                {
                    LabelStatus.Text = "NG";
                    LabelStatus.ForeColor = Color.Red;
                    LabelMessage.Text = "(数据1超时)";
                });
                return;
            }
            if (plc != null && plc.IsOpen())
                plc.Send(byteOK);
            this.Invoke((EventHandler)delegate
            {
                LabelStatus.Text = "OK";
                LabelStatus.ForeColor = Color.Green;
                ListViewItem listDevice02 = new ListViewItem();
                listDevice02.SubItems.Add($"{LvDevice02.Items.Count + 1}");
                listDevice02.SubItems.Add(data);
                LvDevice02.Items.Insert(0, listDevice02);
                LabelMessage.Text = string.Empty;
            });
        }
        /// <summary>
        /// 处理数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="serial"></param>
        /// <returns></returns>
        private string Dealcode(string data, SerialCOM serial)
        {
            try
            {
                data = data.Replace("\r", "").Replace("\n", "").Replace(" ", "");
                int indexOfStart = data.IndexOf(serial.strStart) + serial.strStart.Length;
                int indexOfEnd = data.IndexOf(serial.strEnd);
                data = data.Substring(indexOfStart, indexOfEnd - indexOfStart);
                return data;
            }
            catch (Exception e)
            {
                Message.Warning($"数据处理\n{e.Message}【{data}】");
                return data;
            }
        }

        /// <summary>
        /// 字符串转16进制字节数组
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        private static byte[] StrToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2).Trim(), 16);
            return returnBytes;
        }

        private void ChBox_Enable_CheckedChanged(object sender, EventArgs e)
        {
            if(ChBox_Enable.Checked)
            {
                FrmPLCOrder order = new FrmPLCOrder();
                order.ShowDialog();
            }
        }

        private void Numeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.Handled = true;
            }
        }
    }
}
