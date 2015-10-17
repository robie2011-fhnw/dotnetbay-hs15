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
        public MainWindow()
        {
            if ((Application.Current as App) != null)
            {
                var service = new AuctionService(
                    App.MainRepository, 
                    new SimpleMemberService(App.MainRepository));

                service.GetAll()
                    .ToList()
                    .ForEach(a => this.Auctions.Add(a));
            }
            this.DataContext = this;
            this.InitializeComponent();
        }




        private readonly ObservableCollection<Auction> auctions = new ObservableCollection<Auction>();

        public ObservableCollection<Auction> Auctions
        {
            get { return this.auctions; }
        }

        private void btnNewAuction_Click(object sender, RoutedEventArgs e)
        {
            var newAuctionview = new NewAuctionView();
            newAuctionview.ShowDialog();
        }
    }


    public class BooleanToStateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //should always work. Otherwise we have corrupt data and the application shall crash
            return (bool)value ? "Offen" : "Abgeschlossen";            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
