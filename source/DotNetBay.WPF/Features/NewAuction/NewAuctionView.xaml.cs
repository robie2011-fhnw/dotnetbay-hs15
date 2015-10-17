using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using DotNetBay.Model;

namespace DotNetBay.WPF
{
    /// <summary>
    /// Interaction logic for NewAuctionView.xaml
    /// </summary>
    public partial class NewAuctionView : Window
    {
        private readonly NewAuctionViewModel model;
        public NewAuctionView()
        {
            model = new NewAuctionViewModel();
            DataContext = model;
            InitializeComponent();
        }

        private void ShowFileDialog(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            if(dialog.ShowDialog() == true)
            {
                model.ImagePath = dialog.FileName;
            }
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddAuction(object sender, RoutedEventArgs e)
        {
            var auction = new Auction
            {
                Title = model.Title,
                Description = model.Description,
                StartPrice = double.Parse(model.StartPrice),
                StartDateTimeUtc = model.StartDate,
                EndDateTimeUtc = model.EndDate,
                Image = File.ReadAllBytes(model.ImagePath),
                Seller = App.MemberService.GetCurrentMember()
            };

            App.MainRepository.Add(auction);
            App.MainRepository.SaveChanges();
            
            this.Close();
        }
    }
}
