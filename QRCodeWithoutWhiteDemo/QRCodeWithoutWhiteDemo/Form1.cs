using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using ZXing.QrCode.Internal;

namespace QRCodeWithoutWhiteDemo
{
    public partial class Form1 : Form
    {
        string str = "GSY0GME4R0002497";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            EncodingOptions encodeOption = new EncodingOptions();
            encodeOption.Height = 200;
            encodeOption.Width = 200;

            BarcodeWriter bw = new BarcodeWriter();
            bw.Options = encodeOption;
            bw.Format = BarcodeFormat.QR_CODE;
            Bitmap bmp = bw.Write(str);
            int top = 0, left = 0;
            int right = bmp.Width, bottom = bmp.Height;

            //寻找最上面的标线,从左(0)到右，从上(0)到下  
            for (int i = 0; i < bmp.Height; i++)//行  
            {
                bool find = false;
                for (int j = 0; j < bmp.Width; j++)//列  
                {
                    Color c = bmp.GetPixel(j, i);
                    if (IsWhite(c))
                    {
                        top = i;
                        find = true;
                        break;
                    }
                }
                if (find) break;
            }
            //寻找最左边的标线，从上（top位）到下，从左到右  
            for (int i = 0; i < bmp.Width; i++)//列  
            {
                bool find = false;
                for (int j = top; j < bmp.Height; j++)//行  
                {
                    Color c = bmp.GetPixel(i, j);
                    if (IsWhite(c))
                    {
                        left = i;
                        find = true;
                        break;
                    }
                }
                if (find) break; ;
            }
            ////寻找最下边标线，从下到上，从左到右  
            for (int i = bmp.Height - 1; i >= 0; i--)//行  
            {
                bool find = false;
                for (int j = left; j < bmp.Width; j++)//列  
                {
                    Color c = bmp.GetPixel(j, i);
                    if (IsWhite(c))
                    {
                        bottom = i;
                        find = true;
                        break;
                    }
                }
                if (find) break;
            }
            //寻找最右边的标线，从上到下，从右往左  
            for (int i = bmp.Width - 1; i >= 0; i--)//列  
            {
                bool find = false;
                for (int j = 0; j <= bottom; j++)//行  
                {
                    Color c = bmp.GetPixel(i, j);
                    if (IsWhite(c))
                    {
                        right = i;
                        find = true;
                        break;
                    }
                }
                if (find) break;
            }
            int iWidth = right - left;
            int iHeight = bottom - left;
            int blockWidth = Convert.ToInt32(iWidth * 0 / 100);//需要保留的空白比例
            bmp = Cut(bmp, left - blockWidth, top - blockWidth, right - left + 2 * blockWidth, bottom - top + 2 * blockWidth);
            if (bmp != null)
            {
                pictureBox2.Image = bmp;
            }
        }

        public static Bitmap Cut(Bitmap b, int StartX, int StartY, int iWidth, int iHeight)
        {
            if (b == null)
            {
                return null;
            }
            int w = b.Width;
            int h = b.Height;
            if (StartX >= w || StartY >= h)
            {
                return null;
            }
            if (StartX + iWidth > w)
            {
                iWidth = w - StartX;
            }
            if (StartY + iHeight > h)
            {
                iHeight = h - StartY;
            }
            try
            {
                Bitmap bmpOut = new Bitmap(iWidth, iHeight, PixelFormat.Format24bppRgb);
                Graphics g = Graphics.FromImage(bmpOut);
                g.DrawImage(b, new Rectangle(0, 0, iWidth, iHeight), new Rectangle(StartX, StartY, iWidth, iHeight), GraphicsUnit.Pixel);
                g.Dispose();
                return bmpOut;
            }
            catch
            {
                return null;
            }
        }

        private bool IsWhite(Color c)
        {
            if (c.R < 245 || c.G < 245 || c.B < 245)
                return true;
            else
                return false;
        }
    }
}
