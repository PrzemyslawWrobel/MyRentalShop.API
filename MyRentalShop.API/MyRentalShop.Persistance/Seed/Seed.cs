using Microsoft.EntityFrameworkCore;
using MyRentalShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRentalShop.Persistance.Seed
{
    public static class Seed
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Customer>(d =>
            //{
            //    d.HasData(new Customer(){Id = 1, CustomerTypeId = 1, Name = "Comarch", RegistrationDate = DateTime.Now, AgeCustomer = 21, 
            //        CustomerStatusId = 1, NIP = "6591786532", REGON = "", IsActiv = true});
            //    d.HasData(new ContactPerson() { Id = 1,  CustomerId = 1, Position = "Sekretarka"});
            //    //d.OwnsOne(d => d.CustomerContactPerson).HasData(new { Id = 1, CustomerID = 1, FirstName = "Jaś", SecondName = String.Empty, LastName = "Fasola" });

            //    //d.HasData(new CustomerType(){Id = 1, Name = "Firma"});
            //   // d.HasData(new Address() { Id = 1, CustomerId = 1, AddressType = "Firmowy", Street = "Jana Pawła II", BuildingNumber = "179", 
            //      //  FlatNumber = "2B", ZipCode = "43-300", City = "Kraków", Country = "Poland" });

            //});
            ////modelBuilder.Entity<ContactPerson>(c => c.OwnsOne(c =>c.PersonName).HasData(new {Id = 1, CustomerID = 1, FirstName = "Jaś", 
            ////SecondName = String.Empty, LastName = "Fasola" }));


            modelBuilder.Entity<CustomerType>().HasData(new CustomerType() 
            { 
                Id = 1, 
                Name = "Firma" 
            });

            modelBuilder.Entity<ContactPerson>().HasData(new ContactPerson()
            {
                Id = 1,
                CustomerId = 1,
                Position = "Sekretarka",
            });

            modelBuilder.Entity<ContactPerson>(c => c.OwnsOne(c => c.PersonName).HasData(new 
            { 
                Id = 1, 
                CustomerID = 1, 
                FirstName = "Jaś", 
                SecondName = String.Empty, 
                LastName = "Fasola", 
                ContactPersonId = 1 
            }));
            
            modelBuilder.Entity<Customer>().HasData(new Customer()
            {
                Id = 1,
                CustomerTypeId = 1,
                Name = "Comarch",
                RegistrationDate = DateTime.Now,
                AgeCustomer = 21,
                CustomerStatusId = 1,
                NIP = "6591786532",
                REGON = "",
                IsActiv = true,

            });
            modelBuilder.Entity<Address>().HasData(new Address() 
            { 
                Id = 1, 
                CustomerId = 1, 
                AddressType = "Firmowy",
                Street = "Jana Pawła II",
                BuildingNumber = "179", 
                FlatNumber = "2B", 
                ZipCode = "43-300", 
                City = "Kraków", 
                Country = "Poland" 
            });
            //
            //2 User
            modelBuilder.Entity<CustomerType>().HasData(new CustomerType()
            {
                Id = 2,
                Name = "Firma"
            });

            modelBuilder.Entity<ContactPerson>().HasData(new ContactPerson()
            {
                Id = 2,
                CustomerId = 2,
                Position = "Sekretarka",
            });

            modelBuilder.Entity<ContactPerson>(c => c.OwnsOne(c => c.PersonName).HasData(new
            {
                Id = 2,
                CustomerID = 2,
                FirstName = "Kaczor",
                SecondName = String.Empty,
                LastName = "Donald",
                ContactPersonId = 2
            }));

            modelBuilder.Entity<Customer>().HasData(new Customer()
            {
                Id = 2,
                CustomerTypeId = 2,
                Name = "Jantar",
                RegistrationDate = DateTime.Now,
                AgeCustomer = 21,
                CustomerStatusId = 1,
                NIP = "6591786534",
                REGON = "",
                IsActiv = true,

            });
            modelBuilder.Entity<Address>().HasData(new Address()
            {
                Id = 2,
                CustomerId = 2,
                AddressType = "Firmowy",
                Street = "Piekarska II",
                BuildingNumber = "179",
                FlatNumber = "6B",
                ZipCode = "43-300",
                City = "Bielsko-Biała",
                Country = "Poland"
            });
        }
    }
}
