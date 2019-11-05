using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SerialPortTest
{
    public class Message
    {
        public static void Warning(string message)
        {
            MessageBox.Show(message, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
        }
    }
}
