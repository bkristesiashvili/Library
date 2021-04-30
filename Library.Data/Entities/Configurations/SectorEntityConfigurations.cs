using Library.Data.Entities.Configurations.Abstractions;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Data.Entities.Configurations
{
    internal sealed class SectorEntityConfigurations
        : EntityBaseConfiguration<Sector>
    {
        public override void Configure(EntityTypeBuilder<Sector> builder)
        {
            builder.HasMany(entity => entity.Sections)
                   .WithOne(entity => entity.Sector)
                   .HasForeignKey(entity => entity.SectorId);

            base.Configure(builder);
        }
    }
}
