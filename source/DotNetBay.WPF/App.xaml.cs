using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using DotNetBay.Core.Execution;
using DotNetBay.Data.FileStorage;
using DotNetBay.Interfaces;

namespace DotNetBay.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IMainRepository MainRepository { get; } = new FileSystemMainRepository("file.dat");

        public IAuctionRunner AuctionRunner { get { return auctionRunner; }}
        private static IAuctionRunner auctionRunner;
        public App()
        {
            auctionRunner = new AuctionRunner(this.MainRepository);
            AuctionRunner.Start();
        }
    }
}
