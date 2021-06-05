using Library.Data.Entities.Configurations.Abstractions;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Data.Entities.Configurations
{
    internal sealed class SystemErrorEntityConfigurations 
        : EntityBaseConfiguration<SystemError>
    {
        public override void Configure(EntityTypeBuilder<SystemError> builder)
        {
            builder.Property(entity => entity.Resolved)
                   .HasDefaultValue(false)
                   .ValueGeneratedOnAdd();

            builder.Property(entity => entity.Comment)
                .HasDefaultValue(string.Empty)
                .ValueGeneratedOnAdd();

            base.Configure(builder);
        }
    }
}
