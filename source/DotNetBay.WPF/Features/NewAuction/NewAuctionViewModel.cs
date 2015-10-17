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
using PropertyChanged;

namespace DotNetBay.WPF
{
    [ImplementPropertyChanged]
    public class NewAuctionViewModel : ViewModelBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string StartPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ImagePath { get; set; }
        public string Errors { get; set; }

        public NewAuctionViewModel()
        {
            StartDate = DateTime.Now;
            EndDate = DateTime.Now.AddDays(1);
        }
    }
}
