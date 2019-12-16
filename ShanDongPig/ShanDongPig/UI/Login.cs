using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ShanDongPig.Common;

namespace ShanDongPig.UI
{
    public partial class Login : DevExpress.XtraEditors.XtraForm
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Btn_Login_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void Login1_Load(object sender, EventArgs e)
        {
            txtBox_User.SetWatermark("请输入账号");
            txtBox_Pwd.SetWatermark("请输入密码");
        }
    }
}