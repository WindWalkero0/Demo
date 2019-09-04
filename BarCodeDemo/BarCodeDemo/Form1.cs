using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;

namespace BarCodeDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1.设置条形码规格
            EncodingOptions encodeOption = new EncodingOptions();
            encodeOption.Height = 150; // 必须制定高度、宽度
            encodeOption.Width = 320;
            encodeOption.PureBarcode = false;

            // 2.生成条形码图片并保存
            BarcodeWriter wr = new BarcodeWriter();
            wr.Options = encodeOption;
            wr.Format = BarcodeFormat.CODE_128; //  条形码规格：EAN13规格：12（无校验位）或13位数字
            
            Image img = null;
            try
            {
                img = wr.Write(textBox1.Text); // 生成图片
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            pictureBox1.Image = img;
        }
    }
}
