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
    public class ContactDetailTypeConfiguration : IEntityTypeConfiguration<ContactDetailType>
    {
        public void Configure(EntityTypeBuilder<ContactDetailType> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(300);
        }
    }
}
