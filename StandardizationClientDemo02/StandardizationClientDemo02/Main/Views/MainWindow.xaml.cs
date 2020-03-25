using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using StandardizationClientDemo02.Login.Views;
using StandardizationClientDemo02.Main.Views.UserControls;

namespace StandardizationClientDemo02.Main.Views
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //登陆模块处理
            LoginMainWindow loginMainWindow = new LoginMainWindow();
            bool dialogResult = loginMainWindow.ShowDialog().Value;
            if(!dialogResult)
            {
                Environment.Exit(0);
            }
            InitializeComponent();
        }
    }
}
