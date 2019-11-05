using GongNiu.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SerialPortTest
{
    public class SerialCOM : BaseScan
    {
        JGWSerialPort jGWSerialPort = new JGWSerialPort();
        public SerialCOM()
        {
            jGWSerialPort.DealMethod = new JGWSerialPort.DelegateDealMethod(ScanMethod);
        }
        public override bool Start()
        {
            try
            {
                jGWSerialPort.PortName = ComName;
                jGWSerialPort.BaudRate = BaudRate;
                jGWSerialPort.beginFlag = strStart;
                jGWSerialPort.endFlag = strEnd;
                
                jGWSerialPort.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public override void Stop()
        {
            jGWSerialPort.Close();
        }
        /// <summary>
        /// 端口是否开启
        /// </summary>
        /// <returns></returns>
        public bool IsOpen()
        {
            if (jGWSerialPort.IsOpen)
                return true;
            else
                return false;
        }

        private void ScanMethod(object[] per)
        {
            DealMethod?.Invoke(per[0].ToString());
        }

        public override void Send(byte[] str)
        {
            //jGWSerialPort.SendText(Encoding.Default.GetString(str));
            jGWSerialPort.Write(str, 0, str.Length);
        }

        public override void Send(string str)
        {
            //jGWSerialPort.Write(str);
            jGWSerialPort.SendText(str);
        }
    }
}
