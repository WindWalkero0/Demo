using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InternalMemory
{
    public partial class Form1 : Form
    {
        private int iCount = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //for (int i = 0; i < 1000; i++)
                //{

                iCount++;
                listBox1.Items.Add($"第{iCount}行");
                if (listBox1.Items.Count >= 10)
                {
                    listBox1.Items.RemoveAt(listBox1.Items.Count - 1);
                    GC.Collect();
                }
                System.Threading.Thread.Sleep(1500);
                //}
            }
        }
    }
}
