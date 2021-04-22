using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using MyRentalShop.Domain.Common;
using MyRentalShop.Domain.Entities;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MyRentalShop.Persistance.Seed;
using System.Reflection;

namespace MyRentalShop.Persistance
{
    public class MyRentalShopDbContext : DbContext
    {
        public MyRentalShopDbContext(DbContextOptions<MyRentalShopDbContext> options) : base(options)
        {

        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<ContactPerson> ContactPersons { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerType> CustomerTypes { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemTag> ItemTags { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configuration loaded from folder configuration  
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.SeedData();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = string.Empty;
                        entry.Entity.Created = DateTime.Now;//
                        entry.Entity.StatusId = 1;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedBy = string.Empty;
                        entry.Entity.Modified = DateTime.Now; //_dateTime.Now;
                        break;
                    case EntityState.Deleted:
                        entry.Entity.ModifiedBy = string.Empty;
                        entry.Entity.Modified = DateTime.Now; // _dateTime.Now;
                        entry.Entity.Inactivated = DateTime.Now;//_dateTime.Now;
                        entry.Entity.InactivatedBy = string.Empty;
                        entry.Entity.StatusId = 0;
                        entry.State = EntityState.Modified;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
