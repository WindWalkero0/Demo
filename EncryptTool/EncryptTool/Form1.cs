using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EncryptTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                MD5CryptoServiceProvider cryptoServiceProvider = new MD5CryptoServiceProvider();
                byte[] bytes = Encoding.Default.GetBytes(textBox1.Text.Trim().Insert(3, "lucky"));
                textBox2.Text = BitConverter.ToString(cryptoServiceProvider.ComputeHash(bytes)).Replace("-", "");
            }
            else
            {
                MessageBox.Show("MAC地址栏不能为空!");
            }
        }
    }
}
