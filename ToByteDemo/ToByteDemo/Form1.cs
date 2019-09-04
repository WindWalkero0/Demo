using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToByteDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] buffer = new byte[1024];
            buffer[0] = Convert.ToByte(textBox1.Text.Trim());
            MessageBox.Show(Encoding.Default.GetString(buffer));
        }
    }
}
