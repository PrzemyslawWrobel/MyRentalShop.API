using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyRentalShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRentalShop.Persistance.Configurations
{
    public class ContactPersonConfiguration : IEntityTypeConfiguration<ContactPerson>
    {
        public void Configure(EntityTypeBuilder<ContactPerson> builder)
        {
            builder.OwnsOne(p => p.PersonName).Property(p => p.FirstName).HasMaxLength(100).IsRequired().HasColumnName("FirstName");
            builder.OwnsOne(p => p.PersonName).Property(p => p.SecondName).HasMaxLength(100).HasColumnName("SecondName");
            builder.OwnsOne(p => p.PersonName).Property(p => p.LastName).HasMaxLength(100).IsRequired().HasColumnName("LastName");
        }

    }
}
