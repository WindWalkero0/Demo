using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace SerialPortTest
{
    public abstract class BaseScan
    {
        public delegate void DelegateDealMethod(string per);
        public DelegateDealMethod DealMethod = null;
        /// <summary>
        /// 起始符
        /// </summary>
        public string strStart { get; set; }

        /// <summary>
        /// 终止符
        /// </summary>
        public string strEnd { get; set; }
        public abstract bool Start();
        public abstract void Stop();

        public abstract void Send(byte[] str);
        public abstract void Send(string str);

        #region 网口
        public string IP = "";
        public int Port = 80;
        #endregion

        #region 串口
        public string ComName = "Com1";
        public int BaudRate = 9600;
        //public bool IsHex = false;
        #endregion
    }
}
