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

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddAuction(object sender, RoutedEventArgs e)
        {
            App.MainRepository.Add(new Auction
            {
                Title = txtTitle.Text,
                Description = txtDescription.Content.ToString(),
                StartPrice = double.Parse(txtStartPrice.Text),
                StartDateTimeUtc = dateStart.SelectedDate.Value,
                EndDateTimeUtc = dateEnd.SelectedDate.Value,
                Image = File.ReadAllBytes(txtImagepath.Text),
                Seller = App.MemberService.GetCurrentMember()
            });
            App.MainRepository.SaveChanges();
            this.Close();
        }
    }
}
