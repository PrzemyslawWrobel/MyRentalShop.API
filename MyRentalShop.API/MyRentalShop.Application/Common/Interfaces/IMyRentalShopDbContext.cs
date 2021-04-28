using Microsoft.EntityFrameworkCore;
using MyRentalShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyRentalShop.Application.Common.Interfaces
{
    public interface IMyRentalShopDbContext
    {

        DbSet<Address> Addresses { get; set; }
        DbSet<ContactPerson> ContactPersons { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<CustomerType> CustomerTypes { get; set; }
        DbSet<Item> Items { get; set; }
        DbSet<ItemTag> ItemTags { get; set; }
        DbSet<ItemType> ItemTypes { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
