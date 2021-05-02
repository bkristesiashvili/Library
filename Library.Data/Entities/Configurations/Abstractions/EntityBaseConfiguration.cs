using Library.Data.Entities.Abstractions;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Data.Entities.Configurations.Abstractions
{
    public abstract class EntityBaseConfiguration<TEntity>
        : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity, new()
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(entity => entity.Id);

            builder.Property(entity => entity.CreatedAt)
                   .HasDefaultValueSql("GETDATE()");

            builder.Property(entity => entity.UpdatedAt)
                   .HasDefaultValueSql("NULL");

            builder.Property(entity => entity.DeletedAt)
                   .HasDefaultValueSql("NULL");
        }
    }
}
