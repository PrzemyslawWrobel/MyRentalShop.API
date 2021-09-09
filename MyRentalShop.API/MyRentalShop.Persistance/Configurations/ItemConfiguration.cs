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
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(100);
            builder.Property(p => p.SecondName).HasMaxLength(200);
            builder.Property(p => p.InventoryNumber).HasMaxLength(100);
            builder.Property(p => p.MinAgeBorrower).HasMaxLength(100);
        }
    }
}
