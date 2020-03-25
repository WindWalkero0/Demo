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

namespace StandardizationClientDemo02.ProductionReality.Views
{
    /// <summary>
    /// DisplayMainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class DisplayMainWindow : Window
    {
        public DisplayMainWindow()
        {
            InitializeComponent();
        }

        private void lstView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ListView listView = sender as ListView;
            GridView gridView = listView.View as GridView;

            var workingWidth = listView.ActualWidth - SystemParameters.VerticalScrollBarWidth;//获取可显示的真实宽度
            var col1 = 0.10;
            var col2 = 0.20;
            var col3 = 0.30;
            var col4 = 0.40;

            gridView.Columns[0].Width = workingWidth * col1;
            gridView.Columns[1].Width = workingWidth * col2;
            gridView.Columns[2].Width = workingWidth * col3;
            gridView.Columns[3].Width = workingWidth * col4;
        }
    }
}
