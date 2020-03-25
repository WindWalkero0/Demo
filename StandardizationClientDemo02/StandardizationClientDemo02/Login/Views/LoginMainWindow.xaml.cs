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
using StandardizationClientDemo02.Login.ViewModels;

namespace StandardizationClientDemo02.Login.Views
{
    /// <summary>
    /// LoginMainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginMainWindow : Window
    {
        LoginMainWindowViewModel windowViewModel = null;
        public LoginMainWindow()
        {
            InitializeComponent();
            windowViewModel = new LoginMainWindowViewModel();
            windowViewModel.hostWindow = this;
            this.DataContext = windowViewModel;
        }
    }
}
