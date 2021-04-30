using Library.Data.Entities.Configurations.Abstractions;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Data.Entities.Configurations
{
    internal sealed class BookShelveEntityConfigurations
        : EntityBaseConfiguration<BookShelve>
    {
        public override void Configure(EntityTypeBuilder<BookShelve> builder)
        {
            builder.HasMany(entity => entity.Books)
                   .WithOne(entity => entity.BookShelve)
                   .HasForeignKey(entity => entity.BookshelveId);

            base.Configure(builder);
        }
    }
}
