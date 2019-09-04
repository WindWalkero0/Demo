using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwoWindows
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_Transfer transfer = new Form_Transfer();
            transfer.textBox1.Text = "跨窗体修改控件属性";
            if (!string.IsNullOrEmpty(transfer.textBox1.Text))
                MessageBox.Show("调用并修改文本成功！");
            transfer.ShowDialog();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}
