using Library.Common.Enums;
using Library.Common.Requests.Filters.Abstractions;
using Library.Data.Entities.Abstractions;

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
        #region PROPERTIES

        LibraryDbContext DbContext { get; }

        #endregion

        #region METHODS

        Task<IQueryable<TEntity>> GetAll(IFilter filter = null);

        Task<TEntity> GetByIdAsync(Guid id);

        Task CreateAsync(TEntity newRecord);

        Task UpdateAsync(TEntity exitRecord);

        Task DeleteAsync(TEntity deleteRecord, DeletionType type = DeletionType.Soft);

        Task<TEntity> RestoreAsync(TEntity restoreRecord, string tableName, string fieldName);

        #endregion
    }
}
