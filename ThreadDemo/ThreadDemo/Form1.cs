using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadDemo
{
    public partial class Form1 : Form
    {
        Thread th1 = null;
        Thread th2 = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            th1 = new Thread(AcountA);
            th1.Start();
            th2 = new Thread(AcountB);
            th2.Start();
        }

        void AcountA()
        {
            for(int i = 0; i < 20; i++)
            {
                if(i == 5)
                {
                    MessageBox.Show("当前计数为" + i);
                }

                this.Invoke((EventHandler)delegate
                {
                    listBox1.Items.Add(i);
                });
                Thread.Sleep(1000);
            }
        }

        void AcountB()
        {
            for(int i = 0; i < 20; i++)
            {
                this.Invoke((EventHandler)delegate
                {
                    listBox2.Items.Add(i);
                });
                Thread.Sleep(1000);
            }
        }
    }
}
