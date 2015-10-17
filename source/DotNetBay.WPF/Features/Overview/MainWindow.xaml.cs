using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DotNetBay.Core;
using DotNetBay.Model;
using GalaSoft.MvvmLight.CommandWpf;

namespace DotNetBay.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly OverviewViewModel overviewViewModel;

        public MainWindow()
        {
            overviewViewModel = new OverviewViewModel(App.AuctionService, App.AuctionRunner);
            DataContext = overviewViewModel;

            InitializeComponent();            
        }
    }
}
