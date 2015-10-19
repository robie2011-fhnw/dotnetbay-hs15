﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetBay.Interfaces;

namespace DotNetBay.Data.EF
{
    public class EFMainRepositoryFactory : IRepositoryFactory
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IMainRepository CreateMainRepository()
        {
            return new EFMainRepository();
        }
    }
}
