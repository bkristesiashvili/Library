using Library.Data.Entities.Abstractions;
using Library.Data.Request.Filters.Abstractions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Repositories.Abstractions
{
    public interface IRepository<TEntity> : IDisposable
        where TEntity : BaseEntity, new()
    {
        LibraryDbContext DbContext { get; }

        Task<IQueryable<TEntity>> GetAll(IFilter filter = null);

        Task<TEntity> GetById(Guid id);

        Task Create(TEntity newRecord);

        Task Update(TEntity exitRecord);

        Task Delete(TEntity deleteRecord);
    }
}
