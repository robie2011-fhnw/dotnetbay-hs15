using DotNetBay.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DotNetBay.Core;
using DotNetBay.Core.Execution;
using GalaSoft.MvvmLight.Command;

namespace DotNetBay.WPF
{
    public class OverviewViewModel
    {
        public readonly ObservableCollection<Auction> auctions = new ObservableCollection<Auction>();
        private readonly IAuctionService auctionService;
        public ICommand NewAuction { get; private set; }

        public ObservableCollection<Auction> Auctions 
        {
            get { return auctions; }
        }

        public OverviewViewModel(IAuctionService auctionService, IAuctionRunner auctionRunner)
        {
            this.auctionService = auctionService;
            this.ReloadAuctions();

            auctionRunner.Auctioneer.AuctionStarted += ReloadAuctions;
            auctionRunner.Auctioneer.AuctionEnded += ReloadAuctions;
            auctionRunner.Auctioneer.BidAccepted += ReloadAuctions;
            auctionRunner.Auctioneer.BidDeclined += ReloadAuctions;

            NewAuction = new RelayCommand(() => new NewAuctionView().ShowDialog(), () => true);             
        }


        private void ReloadAuctions(object sender = null, object e = null)
        {
            Auctions.Clear();
            auctionService.GetAll()
                .ToList()
                .ForEach(a => this.Auctions.Add(a));
        }

        public void AddAuctionAndNotify(Auction a)
        {
            auctionService.Save(a);            
        }
    }
}
