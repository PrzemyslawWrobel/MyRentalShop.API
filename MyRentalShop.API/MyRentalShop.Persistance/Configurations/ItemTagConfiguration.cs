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
    public class ItemTagConfiguration : IEntityTypeConfiguration<ItemTag>
    {
        public void Configure(EntityTypeBuilder<ItemTag> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(100);
        }
    }
}
