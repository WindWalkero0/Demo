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

namespace DelayForThreadDemo
{
    public partial class Form1 : Form
    {
        Thread t1 = null;
        Thread t2 = null;
        
        public bool iFlagA = false;//线程t1信号量
        public bool a = false;
        public bool iFlagB = false;//线程t2信号量
        public bool b = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            t1 = new Thread(FunctionA);
            t2 = new Thread(FunctionB);
            t1.Start();
            t2.Start();
            MessageBox.Show("线程创建成功", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void FunctionA()
        {
            int i = 0;
            int m = 0;
            while (true)
            {
                if (iFlagA)
                {
                    //timer1.Interval = 10;
                    //timer1.Start();
                    while (!a)
                    {
                        if (2000 == m)
                        {
                            //timer1.Stop();
                            this.Invoke((EventHandler)delegate
                            {
                                listBox1.Items.Insert(0, "超时");
                            });
                            break;
                        }
                        m += 10;
                        Thread.Sleep(10);
                    }
                    if (!a)
                    {
                        iFlagA = false;
                        m = 0;
                        continue;
                    }
                    i++;
                    this.Invoke((EventHandler)delegate
                    {
                        listBox1.Items.Insert(0, i);
                    });
                    iFlagA = false;
                    m = 0;
                }
                Thread.Sleep(10);
            }
        }

        private void FunctionB()
        {
            int j = 0;
            while (true)
            {
                if (iFlagB)
                {
                    a = true;
                    j++;
                    this.Invoke((EventHandler)delegate
                    {
                        listBox2.Items.Insert(0, j);
                    });
                    iFlagB = false;
                    a = false;
                }
                Thread.Sleep(10);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (iFlagB)
                a = true;
            else
                a = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            iFlagA = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            iFlagB = true;
        }
    }
}
