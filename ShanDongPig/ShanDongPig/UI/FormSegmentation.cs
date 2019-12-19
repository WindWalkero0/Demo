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
    public partial class FormSegmentation : DevExpress.XtraEditors.XtraForm
    {
        public FormSegmentation()
        {
            InitializeComponent();
        }

        private void Btn_RepairPrint_Click(object sender, EventArgs e)
        {
            SegmentationEntity segmentation = new SegmentationEntity
            {
                butcherBatch = "123456",
                ribbonCode = "1",
                separateCode = "2",
                separateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };
            InterfaceServices.UploadSegmentation(segmentation, out string error);
        }
    }
}