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
    //TODO: Use AuctionViewModel
    public class OverviewViewModel
    {
        public readonly ObservableCollection<Auction> auctions = new ObservableCollection<Auction>();
        private readonly IAuctionService auctionService;
        public ICommand NewAuction { get; private set; }
        public ObservableCollection<Auction> Auctions => this.auctions;

        public OverviewViewModel(IAuctionService auctionService, IAuctionRunner auctionRunner)
        {
            this.auctionService = auctionService;
            AddNewstAuctionToMainView();

            //auctionRunner.Auctioneer.AuctionStarted += ReloadAuctions;
            //auctionRunner.Auctioneer.AuctionEnded += ReloadAuctions;
            //auctionRunner.Auctioneer.BidAccepted += ReloadAuctions;
            //auctionRunner.Auctioneer.BidDeclined += ReloadAuctions;

            NewAuction = new RelayCommand(ShowGetImageDialog, () => true);             
        }

        private void ShowGetImageDialog()
        {
            new NewAuctionView().ShowDialog();
            AddNewstAuctionToMainView();
        }

        private void AddNewstAuctionToMainView()
        {
            var existingAuctionIds = new HashSet<long>(Auctions.Select(a => a.Id));
            var newAuctions = auctionService.GetAll()
                .Where(a => !existingAuctionIds.Contains(a.Id))
                .ToList();

            newAuctions.ForEach(a => Auctions.Add(a));
        }

        public void AddAuctionAndNotify(Auction a)
        {
            auctionService.Save(a);            
        }
    }
}
