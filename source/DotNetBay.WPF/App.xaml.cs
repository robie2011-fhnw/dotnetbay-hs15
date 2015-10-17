using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using DotNetBay.Core;
using DotNetBay.Core.Execution;
using DotNetBay.Data.FileStorage;
using DotNetBay.Interfaces;
using DotNetBay.Model;

namespace DotNetBay.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static App Instance { get; } = ((App)Application.Current);

        public static readonly IMainRepository MainRepository;
        public static readonly IAuctionRunner AuctionRunner;
        public static readonly IMemberService MemberService;
        public static readonly IAuctionService AuctionService;

        static App()
        {
            SetupCulture();
            MainRepository = new FileSystemMainRepository("file.dat");
            AuctionRunner = new AuctionRunner(MainRepository);
            MemberService = new SimpleMemberService(MainRepository);
            AuctionService = new AuctionService(MainRepository, MemberService);

            InitTestAuctionData();
            AuctionRunner.Start();
        }

        private static void SetupCulture()
        {
            // Do not work
            // todo https://weblog.west-wind.com/posts/2009/Jun/14/WPF-Bindings-and-CurrentCulture-Formatting
            CultureInfo culture = new CultureInfo(ConfigurationManager.AppSettings["DefaultCulture"]);            
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
        }

        private static void InitTestAuctionData()
        {
            if (AuctionService.GetAll().Any())
            {
                var me = MemberService.GetCurrentMember();
                AuctionService.Save(new Auction
                {
                    Title = "My First Auction",
                    StartDateTimeUtc = DateTime.UtcNow.AddSeconds(10),
                    EndDateTimeUtc = DateTime.UtcNow.AddDays(14),
                    StartPrice = 72,
                    Seller = me
                });
            }
        }
    }
}
