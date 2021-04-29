using Library.Data.Entities.Configurations.Abstractions;
using Library.Data.Extensions;
using Library.Data.Seeder;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Data.Entities.Configurations
{
    internal sealed class GenreEntityConfigurations : EntityBaseConfiguration<Genre>
    {
        public override void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasIndex(entity => entity.Name)
                   .IsUnique();

            builder.HasMany(entity => entity.Books)
                   .WithOne(entity => entity.Genre)
                   .HasForeignKey(entity => entity.GenreId);

            builder.SeedData(new GenreSeeder());

            base.Configure(builder);
        }
    }
}
