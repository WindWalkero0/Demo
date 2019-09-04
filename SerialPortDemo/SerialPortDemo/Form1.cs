using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace SerialPortDemo
{
    public partial class Form1 : Form
    {
        SerialPort serial = null;
        Thread th_Recv = null;
        public byte[] buffer = new byte[1024];
        public string str_Recv = string.Empty;
        public int count = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serial = new SerialPort(textBox1.Text.Trim(), 115200, Parity.None, 8, StopBits.One);
            serial.Open();
            if (serial.IsOpen)
            {
                button2.Enabled = false;
                MessageBox.Show("COM连接成功!");
            }
            th_Recv = new Thread(Rece);
            th_Recv.IsBackground = true;
            th_Recv.Start();
        }

        void Rece()
        {
            while (serial.IsOpen)
            {
                try
                {
                    count = serial.Read(buffer, 0, buffer.Length);
                    str_Recv = Encoding.ASCII.GetString(buffer);
                    this.Invoke((EventHandler)delegate
                    {
                        listBox1.Items.Add(str_Recv.Substring(1));
                    });
                }
                catch { }
                Thread.Sleep(10);
            }
        }
        int iCount = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            string chars = "0123456789ABCDEFGHJKLMNPQRSTUVWXYZ";
            Random randrom = new Random((int)DateTime.Now.Ticks);
            StringBuilder stringBuilder = new StringBuilder();
            int count = int.Parse(textBox3.Text.Trim());
            int length = int.Parse(textBox4.Text.Trim());
            for (int i = 0; i < count; i++)
            {
                for (int k = 0; k < length; k++)
                {
                    stringBuilder.Append(chars[randrom.Next(chars.Length)]);
                }
                iCount++;
                listBox1.Invoke((MethodInvoker)delegate
                {
                    listBox1.Items.Insert(0, $"{stringBuilder}{iCount:D7}");
                });
                //serial.Write(string.Format("$JGW1${0}{1}$JGW2$\r\n", stringBuilder, string.Format("{0:D7}", iCount)));
                serial.Write($"{textBoxBegin.Text}{stringBuilder}{iCount:D7}{textBoxEnd.Text}\r\n");
                if (iCount >= 9999999)
                    iCount = 0;
                //Console.WriteLine("第{0}次: 【{1}】", i + 1, str);
                Thread.Sleep(Convert.ToInt32(txtDelay.Text.Trim()));
                stringBuilder.Clear();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            serial.Write(/*$"$JGW1${*/textBox2.Text.Trim()/*}$JGW2$\r\n"*/);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            if (serial != null)
                serial.Close();
        }
    }
}
