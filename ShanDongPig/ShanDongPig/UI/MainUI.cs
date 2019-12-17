using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using ShanDongPig.Common;

namespace ShanDongPig.UI
{
    public partial class MainUI : XtraForm
    {
        //界面
        private FormIndex mFormIndex = null;
        private FormSlaughter mFormSlaughter = null;
        private FormSegmentation mFormSegmentation = null;
        private FormSetting mFormSetting = null;
        private List<XtraForm> formList = new List<XtraForm>();

        public MainUI()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 添加显示界面
        /// </summary>
        private void ShowUI()
        {
            Size size = MainPanel.Size;
            Point location = new Point(0, 0);

            mFormIndex = new FormIndex();
            mFormSlaughter = new FormSlaughter();
            mFormSegmentation = new FormSegmentation();
            mFormSetting = new FormSetting();

            formList.Add(mFormIndex);
            formList.Add(mFormSlaughter);
            formList.Add(mFormSegmentation);
            formList.Add(mFormSetting);

            foreach (XtraForm form in formList)
            {
                form.Size = size;
                form.Location = location;
                form.TopLevel = false;
                MainPanel.Controls.Add(form);
            }
        }

        private void MainUI_Load(object sender, EventArgs e)
        {
            ShowUI();

            ShowPanel(mFormIndex);
        }

        private void ShowPanel(XtraForm formSel)
        {
            foreach (XtraForm form in formList)
            {
                if (form == formSel)
                {
                    form.Show();
                }
                else
                {
                    form.Hide();
                }
            }
        }

        private void Btn_Index_Click(object sender, EventArgs e)
        {
            ShowPanel(mFormIndex);
        }

        private void Btn_Slaughter_Click(object sender, EventArgs e)
        {
            ShowPanel(mFormSlaughter);
        }

        private void Btn_Segmentation_Click(object sender, EventArgs e)
        {
            ShowPanel(mFormSegmentation);
        }

        private void Btn_Setting_Click(object sender, EventArgs e)
        {
            ShowPanel(mFormSetting);
        }

        private void MainPanel_SizeChanged(object sender, EventArgs e)
        {
            Size size = MainPanel.Size;
            Point location = new Point(0, 0);
            foreach(XtraForm form in formList)
            {
                form.Size = size;
                form.Location = location;
            }
        }
    }
}