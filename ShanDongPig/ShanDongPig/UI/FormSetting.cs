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
    public partial class FormSetting : DevExpress.XtraEditors.XtraForm
    {
        public FormSetting()
        {
            InitializeComponent();
        }

        private void FormSetting_Load(object sender, EventArgs e)
        {
            CbxPrinter.Items.Clear();
            List<string> printerList = GetDevicesInfo.GetLocalPrinter();
            if (printerList != null || printerList.Count > 0)
            {
                foreach (string printer in printerList)
                    CbxPrinter.Items.Add(printer);
            }
        }
    }
}