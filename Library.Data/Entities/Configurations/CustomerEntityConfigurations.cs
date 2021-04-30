using Library.Data.Entities.Configurations.Abstractions;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Data.Entities.Configurations
{
    internal sealed class CustomerEntityConfigurations
        : EntityBaseConfiguration<Customer>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasIndex(entity => new
            {
                entity.IdentityNumber,
                entity.Phone,
                entity.Email
            }).IsUnique();

            builder.HasMany(entity => entity.RentedBooks)
                   .WithOne(entity => entity.Customer)
                   .HasForeignKey(entity => entity.CustomerId);

            base.Configure(builder);
        }
    }
}
