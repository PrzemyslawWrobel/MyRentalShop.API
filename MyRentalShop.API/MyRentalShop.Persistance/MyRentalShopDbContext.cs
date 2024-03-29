﻿using Microsoft.EntityFrameworkCore;
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
using MyRentalShop.Application.Common.Interfaces;

namespace MyRentalShop.Persistance
{
    public class MyRentalShopDbContext : DbContext, IMyRentalShopDbContext
    {
        private readonly IDateTime _dateTime;
        private readonly ICurrentUserService _userService;
        public MyRentalShopDbContext(DbContextOptions<MyRentalShopDbContext> options) : base(options)
        {

        }

        public MyRentalShopDbContext(DbContextOptions<MyRentalShopDbContext> options, IDateTime dateTime, ICurrentUserService userService) : base(options)
        {
            _dateTime = dateTime;
            _userService = userService;
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<ContactPerson> ContactPersons { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerType> CustomerTypes { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemTag> ItemTags { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<ContactDetail> ContactDetails { get; set; }
        public DbSet<ContactDetailType> ContactDetailTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
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
                        entry.Entity.CreatedBy = _userService.Email;
                        entry.Entity.Created = _dateTime.Now;
                        entry.Entity.StatusId = 1;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedBy = _userService.Email;
                        entry.Entity.Modified = _dateTime .Now;
                        break;
                    case EntityState.Deleted:
                        entry.Entity.ModifiedBy = _userService.Email;
                        entry.Entity.Modified =  _dateTime.Now;
                        entry.Entity.Inactivated = _dateTime.Now;
                        entry.Entity.InactivatedBy = _userService.Email;
                        entry.Entity.StatusId = 0;
                        entry.State = EntityState.Modified;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
