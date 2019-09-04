using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockThreadDemo
{
    public partial class Form1 : Form
    {
        Thread th = null;
        Thread thread = null;
        static EventWaitHandle eHandle = null;
        int iCount = 0;
        bool bFlag = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (eHandle != null)
                eHandle.Close();
            eHandle = new EventWaitHandle(false, EventResetMode.ManualReset);
            button1.Enabled = false;
            button3.Enabled = true;
            bFlag = true;
            th = new Thread(StartDisplay);
            th.IsBackground = true;
            th.Start();

            thread = new Thread(ListenThread);
            thread.IsBackground = true;
            thread.Start();
        }

        void ListenThread()
        {
            while(true)
            {
                Process pro = Process.GetProcessesByName("BlockThreadDemo")[0];
                int length = pro.Threads.Count;
                this.Invoke((EventHandler)delegate
                {
                    listBox2.Items.Clear();
                    textBox1.Text = length.ToString();
                });
                for(int i = 0; i < length; i++)
                {
                    this.Invoke((EventHandler)delegate
                    {
                        listBox2.Items.Insert(0, pro.Threads[i].Id);
                    });
                }
                Thread.Sleep(1000);
            }
        }

        void StartDisplay()
        {
            while (bFlag)
            {
                eHandle.WaitOne();
                iCount++;
                this.Invoke((EventHandler)delegate
              {
                  listBox1.Items.Insert(0, $"当前序号：{iCount}");
              });
                Thread.Sleep(500);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            eHandle.Set();
            button2.Enabled = false;
            button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            eHandle.Reset();
            button2.Enabled = true;
            button3.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            th = null;
            bFlag = false;
            button1.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string str = textBox1.Text.Trim();
        }
    }
}
