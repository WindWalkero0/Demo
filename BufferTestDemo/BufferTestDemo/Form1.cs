using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BufferTestDemo
{
    public partial class Form1 : Form
    {
        public string str = "kkk";
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            str += "H";
            label1.Text = str;
            int index = str.IndexOf("HHHHHHH");
            if(str.IndexOf("HHHHHHH") > 0)
            {
                timer1.Stop();
                MessageBox.Show("数据接收完成！");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            //timer1.Tick += timer1_Tick;
            timer1.Start();
        }
    }
}
