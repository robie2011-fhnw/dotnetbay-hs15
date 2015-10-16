using Microsoft.Win32;
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

namespace DotNetBay.WPF
{
    /// <summary>
    /// Interaction logic for NewAuctionView.xaml
    /// </summary>
    public partial class NewAuctionView : Window
    {
        public NewAuctionView()
        {
            InitializeComponent();
        }

        private void ShowFileDialog(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            if(dialog.ShowDialog() == true)
            {
                txtImagepath.Text = dialog.FileName;
            }
        }
    }
}
