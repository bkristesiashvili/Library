using Library.Data.Entities.Configurations.Abstractions;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Data.Entities.Configurations
{
    internal sealed class BookEntityConfigurations
        :EntityBaseConfiguration<Book>
    {
        public override void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasIndex(entity => entity.ISBN)
                   .IsUnique();

            builder.HasMany(entity => entity.Authors)
                   .WithOne(entity => entity.Book)
                   .HasForeignKey(entity => entity.BookId);

            base.Configure(builder);
        }
    }
}
