using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CorrdinateGraphDemo
{
    public partial class Form1 : Form
    {
        string[] month = new string[12] { "一月", "二月", "三月", "四月", "五月", "六月", "七月", "八月", "九月", "十月", "十一月", "十二月" };
        float[] d = new float[12] { 20.5F, 60, 30.7F, 10, 80, 40.1F, 25, 50, 40, 70.5F, 35.5F, 60 };
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(500, 500);
            Graphics gh = Graphics.FromImage(bm);
            gh.Clear(Color.White);

            PointF cPt = new PointF(40, 420);    //中心点
            PointF[] xPt = new PointF[3]
            {
                new PointF(cPt.Y+15, cPt.Y),
                new PointF(cPt.Y, cPt.Y - 8),
                new PointF(cPt.Y, cPt.Y + 8)
            }; //X轴三角形

            PointF[] yPt = new PointF[3]
            {
                new PointF(cPt.X, cPt.X - 15),
                new PointF(cPt.X + 8, cPt.X),
                new PointF(cPt.X - 8, cPt.X)
            };  //Y轴三角形
            gh.DrawString("某工厂某产品月生产量图表", new Font("宋体", 14), Brushes.Black, new PointF(cPt.X + 12, cPt.X));
            //画X轴
            gh.DrawLine(Pens.Black, cPt.X, cPt.Y, cPt.Y, cPt.Y);
            gh.DrawPolygon(Pens.Black, yPt);
            gh.FillPolygon(new SolidBrush(Color.Black), xPt);
            gh.DrawString("月份", new Font("宋体", 12), Brushes.Black, new PointF(cPt.Y + 12, cPt.Y - 10));
            //画Y轴
            gh.DrawLine(Pens.Black, cPt.X, cPt.Y, cPt.X, cPt.X);
            gh.DrawPolygon(Pens.Black, yPt);
            gh.FillPolygon(new SolidBrush(Color.Black), yPt);
            gh.DrawString("单位(万)", new Font("宋体", 12), Brushes.Black, new PointF(6, 7));
            for (int i = 1; i <= 12; i++)
            {
                //画Y轴刻度
                if (i < 11)
                {
                    gh.DrawString((i * 10).ToString(), new Font("宋体", 11), Brushes.Black, new PointF(cPt.X - 30, cPt.Y - i * 30 - 6));
                    gh.DrawLine(Pens.Black, cPt.X - 3, cPt.Y - i * 30, cPt.X, cPt.Y - i * 30);
                }
                //画X轴项目
                gh.DrawString(month[i - 1].Substring(0, 1), new Font("宋体", 11), Brushes.Black, new PointF(cPt.X + i * 30 - 5, cPt.Y + 5));
                gh.DrawString(month[i - 1].Substring(1, 1), new Font("宋体", 11), Brushes.Black, new PointF(cPt.X + i * 30 - 5, cPt.Y + 20));
                if(month[i-1].Length > 2)
                {
                    gh.DrawString(month[i - 1].Substring(2, 1), new Font("宋体", 11), Brushes.Black, new PointF(cPt.X + i * 30 - 5, cPt.Y + 35));
                }
                //画点
                gh.DrawEllipse(Pens.Black, cPt.X + i * 30 - 1.5F, cPt.Y - d[i - 1] * 3 + 1.5F, 3, 3);
                gh.FillEllipse(new SolidBrush(Color.Black), cPt.X + i * 30 - 1.5F, cPt.Y - d[i - 1] * 3 + 1.5F, 3, 3);

                //画数值
                gh.DrawString(d[i - 1].ToString(), new Font("宋体", 11), Brushes.Black, new PointF(cPt.X + i * 30, cPt.Y - d[i - 1] * 3));
                
                //画折线
                if(i > 1)
                {
                    gh.DrawLine(Pens.Red, cPt.X + (i - 1) * 30, cPt.Y - d[i - 2] * 3, cPt.X + i * 30, cPt.Y - d[i - 1] * 3);
                }
            }
            //显示在pictureBox控件中
            this.pictureBox1.Image = bm;
        }
    }
}
