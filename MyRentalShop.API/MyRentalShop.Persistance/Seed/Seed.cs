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
            modelBuilder.Entity<Customer>(d =>
            {
                d.HasData(new Customer()
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
                d.HasData(new ContactPerson() { Id = 1,  CustomerId = 1, Position = "Sekretarka",
                });
                //d.OwnsOne(d => d.CustomerContactPerson).HasData(new { Id = 1, CustomerID = 1, FirstName = "Jaś", SecondName = String.Empty, LastName = "Fasola" });

                d.HasData(new CustomerType(){Id = 1, Name = "Firma"});
                d.HasData(new Address() { Id = 1, CustomerId = 1, AddressType = "Firmowy", Street = "Jana Pawła II", BuildingNumber = "179", FlatNumber = "2B", ZipCode = "43-300", City = "Kraków", Country = "Poland" });

            });
            modelBuilder.Entity<ContactPerson>(c => c.OwnsOne(c =>c.PersonName).HasData(new {Id = 1, CustomerID = 1, FirstName = "Jaś", SecondName = String.Empty, LastName = "Fasola" }));

        }
    }
}
