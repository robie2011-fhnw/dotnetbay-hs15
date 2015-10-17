using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using DotNetBay.WPF.Annotations;
using GalaSoft.MvvmLight;

namespace DotNetBay.WPF
{
    public class NewAuctionViewModel : ViewModelBase
    {
        private string title,
            description,
            startPrice,
            imagePath;

        private DateTime startDate = DateTime.Now;
        private DateTime endDate = DateTime.Now.AddDays(1);

        public string Title
        {
            get { return title; }

            set {
                Console.WriteLine(value);
                Set(() => Title, ref title, value); }
        }

        public string Description
        {
            get { return description;}
            set { Set(() => Description, ref description, value); }
        }

        public string StartPrice
        {
            get { return startPrice; }
            set { Set(() => StartPrice, ref startPrice, value); }
        }

        public DateTime EndDate 
        {
            get { return endDate;}
            set { Set(() => EndDate, ref endDate, value); }
        }

        public DateTime StartDate
        {
            get { return startDate; }
            set { Set(() => StartDate, ref startDate, value); }
        }

        public string ImagePath
        {
            get { return imagePath; }
            set { Set(() => ImagePath, ref imagePath, value); }
        }
    }
}
