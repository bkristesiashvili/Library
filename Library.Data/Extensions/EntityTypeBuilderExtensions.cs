using Library.Data.Entities.Abstractions;
using Library.Data.Seeder.Abstractions;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Data.Extensions
{
    internal static class EntityTypeBuilderExtensions
    {
        internal static void SeedData<TEntity>(this EntityTypeBuilder Builder, 
            IDataSeeder<TEntity> dataSeeder) where TEntity : BaseEntity, new()
        {
            if (Builder == null) throw new ArgumentNullException(nameof(Builder));

            Builder.HasData(dataSeeder.ExecuteSeeder());
        }
    }
}
