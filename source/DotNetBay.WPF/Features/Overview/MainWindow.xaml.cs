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

namespace DotNetBay.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ObservableCollection<Auction> auctions = new ObservableCollection<Auction>();

        public ObservableCollection<Auction> Auctions
        {
            get { return auctions; }
        }

        public MainWindow()
        {
            
            //if ((Application.Current as App) != null) // Why is this necessary?
            //{
                ReloadAuctions();
            //}
            this.DataContext = this;
            this.InitializeComponent();
        }

        private void ReloadAuctions()
        {
            Auctions.Clear();
            App.AuctionService.GetAll()
                .ToList()
                .ForEach(a => this.Auctions.Add(a));
        }

        private void btnNewAuction_Click(object sender, RoutedEventArgs e)
        {
            var newAuctionview = new NewAuctionView();
            newAuctionview.ShowDialog();
        }
    }
}
