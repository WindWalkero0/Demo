using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialPortTest
{
    public partial class FrmPLCOrder : Form
    {
        public FrmPLCOrder()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                AppConfig.SetItemValue("OrderOK", tbxNG.Text);
                AppConfig.SetItemValue("OrderNG", tbxOK.Text);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Message.Warning($"保存失败\n{ex.Message}");
            }
        }

        private void FrmPLCOrder_Load(object sender, EventArgs e)
        {
            tbxOK.Text = AppConfig.GetItemValue("OrderOK");
            tbxNG.Text = AppConfig.GetItemValue("OrderNG");
        }
    }
}
