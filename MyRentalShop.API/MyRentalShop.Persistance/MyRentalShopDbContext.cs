using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRentalShop.Persistance
{
    public class MyRentalShopDbContext : DbContext
    {
        public MyRentalShopDbContext(DbContextOptions<MyRentalShopDbContext> options) : base(options)
        {

        }
    }
}
