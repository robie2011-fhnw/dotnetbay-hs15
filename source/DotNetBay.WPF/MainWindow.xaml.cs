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
                var service = new AuctionService(((App)Application.Current).MainRepository, new SimpleMemberService(((App)Application.Current).MainRepository));
                foreach (var auction in service.GetAll())
                {
                    this.Auctions.Add(auction);
                }
            }
            this.DataContext = this;
            this.InitializeComponent();
        }




        private readonly ObservableCollection<Auction> auctions = new ObservableCollection<Auction>();

        public ObservableCollection<Auction> Auctions
        {
            get { return this.auctions; }
        }

    }


    public class BooleanToStateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.GetType() == typeof (bool))
            {
                bool b = (bool) value;
                if (b)
                    return "Offen";
                return "Abgeschlossen";
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
