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
        string segmentationCode = string.Empty;
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

        private void DealPrint(string data)
        {

        }

        private void PrinterDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                //箱码
                e.Graphics.DrawString(segmentationCode, new Font("黑体", Tools.GetLocation(GeneralData.GetConfigItem("CodeSize")), FontStyle.Bold),
             new SolidBrush(Color.Black), new Point(Tools.GetLocation(GeneralData.GetConfigItem("CodeX")), Tools.GetLocation(GeneralData.GetConfigItem("CodeY"))));
                //箱码二维码
                Image qr = Tools.GetQRCode(segmentationCode);
                e.Graphics.DrawImage(qr, Tools.GetLocation(GeneralData.GetConfigItem("QRCodeX")), Tools.GetLocation(GeneralData.GetConfigItem("QRCodeY")),
                    Tools.GetLocation(GeneralData.GetConfigItem("QRCodeSize")), Tools.GetLocation(GeneralData.GetConfigItem("QRCodeSize")));
            }
            catch(Exception ex)
            {

            }
        }
    }
}