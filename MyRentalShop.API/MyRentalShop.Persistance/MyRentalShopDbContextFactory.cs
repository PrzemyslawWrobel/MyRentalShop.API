using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRentalShop.Persistance
{
    public class MyRentalShopDbContextFactory : DesignTimeDbContextFactoryBase<MyRentalShopDbContext>
    {
        protected override MyRentalShopDbContext CreateNewInstance(DbContextOptions<MyRentalShopDbContext> options)
        {
            return new MyRentalShopDbContext(options);
        }
    }
}
