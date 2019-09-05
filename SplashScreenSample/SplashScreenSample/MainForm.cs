using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SplashScreenSample
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Splasher.Show(typeof(FrmSplashScreen));
            System.Threading.Thread.Sleep(800);
            Splasher.Status = "正在展示相关内容......";
            Thread.Sleep(1000);
            Splasher.Status = "加载完毕......";
            Thread.Sleep(1000);
            Splasher.Close();
        }
    }
}
