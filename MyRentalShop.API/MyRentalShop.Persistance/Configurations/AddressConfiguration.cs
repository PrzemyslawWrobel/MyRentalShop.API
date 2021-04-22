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
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(p => p.AddressType).HasMaxLength(100);
            builder.Property(p => p.Street).HasMaxLength(100);
            builder.Property(p => p.BuildingNumber).HasMaxLength(100);
            builder.Property(p => p.FlatNumber).HasMaxLength(100);
            builder.Property(p => p.ZipCode).HasMaxLength(100);
            builder.Property(p => p.City).HasMaxLength(100);
            builder.Property(p => p.Country).HasMaxLength(100);
        }
    }
}
