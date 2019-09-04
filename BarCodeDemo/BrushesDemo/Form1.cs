/********************遍历颜色***********************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrushesDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = 0;//X坐标
            int y = 0;//Y坐标
            int n = 0;//计数
            foreach (var item in typeof(Brushes).GetMembers())
            {
                if (item.MemberType == System.Reflection.MemberTypes.Property &&
                    System.Drawing.Color.FromName(item.Name).IsKnownColor == true)
                {
                    Label myLabel = new Label();
                    myLabel.AutoSize = true;
                    myLabel.ForeColor = System.Drawing.Color.FromName(item.Name);
                    myLabel.Text = item.Name;
                    if(n % 4 == 0)
                    {
                        x = 0;
                        y += 30;
                    }
                    x += 100;
                    myLabel.Location = new Point(x, y);

                    panel1.Controls.Add(myLabel);
                    n++;
                }
            }
        }
    }
}
