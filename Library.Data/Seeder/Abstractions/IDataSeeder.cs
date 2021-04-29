using Library.Data.Entities.Abstractions;

using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Data.Seeder.Abstractions
{
    public interface IDataSeeder<TEntity>
        where TEntity : BaseEntity, new()
    {
        IReadOnlyList<TEntity> ExecuteSeeder();
    }
}
