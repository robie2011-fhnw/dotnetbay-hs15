﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
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

        static App()
        {
            MainRepository = new FileSystemMainRepository("file.dat");
            AuctionRunner = new AuctionRunner(MainRepository);
            MemberService = new SimpleMemberService(MainRepository);

            InitRepository();
            AuctionRunner.Start();
        }


        private static void InitRepository()
        {
            var memberService = new SimpleMemberService(MainRepository);
            var service = new AuctionService(MainRepository, memberService);
            if (!service.GetAll().Any())
            {
                var me = memberService.GetCurrentMember();
                service.Save(new Auction
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
