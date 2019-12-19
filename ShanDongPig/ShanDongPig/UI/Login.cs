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
using ShanDongPig.Entities;

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
            //首先是要登录成功
            if (!Tools.IsExistName("machineID"))
            {
                ResultEntity result = HttpUtil.HttpGet("http://192.168.20.64:7790/hydra-shandong-pingan-pig-batcher/api/v1/separate/production-line/code-flag");
                if(result.State == 200)
                {
                    Tools.SetRegKey("machineID", result.Results);
                }
                else
                {
                    MyMessage.Warning(result.Msg);
                }
            }
            this.DialogResult = DialogResult.OK;
        }

        private void Login1_Load(object sender, EventArgs e)
        {
            txtBox_User.SetWatermark("请输入账号");
            txtBox_Pwd.SetWatermark("请输入密码");
        }
    }
}