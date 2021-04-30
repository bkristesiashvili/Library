using Library.Data.Entities.Configurations.Abstractions;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Data.Entities.Configurations
{
    internal sealed class SectionEntityConfigurations
        : EntityBaseConfiguration<Section>
    {
        public override void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.HasMany(entity => entity.BookShelves)
                   .WithOne(entity => entity.Section)
                   .HasForeignKey(entity => entity.SectionId);

            base.Configure(builder);
        }
    }
}
