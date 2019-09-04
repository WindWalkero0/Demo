using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckedBoxDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "取消")
            {
                checkBox1.Checked = false;
                button1.Text = "打勾";
            }
            else
            {
                checkBox1.Checked = true;
                button1.Text = "取消";
            }
        }
    }
}
