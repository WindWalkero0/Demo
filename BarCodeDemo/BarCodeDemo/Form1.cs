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

namespace BarCodeDemo
{
    public partial class Form1 : Form
    {
        public static int horizonCount = 0;
        public static int length = 200;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string beginStr = textBox1.Text;
                string currentStr = string.Empty;
                int indexLength = Convert.ToInt32(textBox3.Text.Trim());
                for (int i = 0; i < Convert.ToInt32(textBox2.Text); i++)
                {
                    currentStr = beginStr.Substring(0, beginStr.Length - indexLength) + (Convert.ToInt32(beginStr.Substring(beginStr.Length - indexLength, indexLength)) + i);
                    
                    // 1.设置条形码规格
                    EncodingOptions encodeOption = new EncodingOptions();
                    encodeOption.Height = 100; // 必须制定高度、宽度
                    encodeOption.Width = 100;
                    encodeOption.PureBarcode = false;

                    // 2.生成条形码图片并保存
                    BarcodeWriter wr = new BarcodeWriter();
                    wr.Options = encodeOption;
                    wr.Format = BarcodeFormat.QR_CODE; //  条形码规格：EAN13规格：12（无校验位）或13位数字

                    Bitmap bmp = null;
                    try
                    {
                        bmp = wr.Write(currentStr); // 生成图片
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    int count = 0;
                    foreach (Control c in panel1.Controls)
                    {
                        if (c is PictureBox)
                            count++;
                    }
                    if ((panel1.Width / length) * (panel1.Height / length) <= count)
                    {
                        MessageBox.Show("放不下，或者放大窗口");
                        return;
                    }
                    PictureBox pb = new PictureBox
                    {
                        Image = bmp,
                        Size = new Size(100, 100),
                        Location = new Point((count % horizonCount) * length, (count / horizonCount) * length)
                    };

                    panel1.Controls.Add(pb);
                    textBox1.Text = currentStr.PadLeft(indexLength, '0');
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Bitmap DealImage(Bitmap bmp)
        {
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
            return bmp;
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


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(null, null);
            }
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            horizonCount = panel1.Width / length;
            if (horizonCount <= 0)
                return;
            List<PictureBox> pictureBoxes = new List<PictureBox>();
            foreach (Control c in panel1.Controls)
            {
                if (c is PictureBox)
                {
                    pictureBoxes.Add(c as PictureBox);
                }
            }
            panel1.Controls.Clear();
            int count = pictureBoxes.Count;
            int index = 0;
            foreach (PictureBox pb in pictureBoxes)
            {
                pb.Location = new Point(length * (index % horizonCount), length * (index / horizonCount));
                index++;
            }
            panel1.Controls.AddRange(pictureBoxes.ToArray());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            horizonCount = panel1.Width / length;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
        }
    }
}
