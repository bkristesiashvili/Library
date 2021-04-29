using Library.Data.Entities.Configurations.Abstractions;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Data.Entities.Configurations
{
    internal sealed class AuthorEntityConfigurations
        : EntityBaseConfiguration<Author>
    {
        public override void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasMany(entity => entity.Books)
                   .WithOne(entity => entity.Author)
                   .HasForeignKey(entity => entity.AuthorId);

            base.Configure(builder);
        }
    }
}
