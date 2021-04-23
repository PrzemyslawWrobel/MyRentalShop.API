﻿using MyRentalShop.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRentalShop.Infrastructure.Services
{
    public class DataTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
