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
    /// Interaction logic for NewBidView.xaml
    /// </summary>
    public partial class NewBidView : Window
    {
        public NewBidView()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //var bidValue = Convert.ToDouble(this.textBox.Text);

            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Values!");
            }
        }
    }
}
