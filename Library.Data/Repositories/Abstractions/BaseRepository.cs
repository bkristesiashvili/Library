using Library.Data.Entities.Abstractions;
using Library.Data.Request.Filters.Abstractions;
using Library.Data.Extensions;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Repositories.Abstractions
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : BaseEntity, new()
    {
        public LibraryDbContext DbContext { get; }

        private readonly DbSet<TEntity> Entity;

        public BaseRepository(LibraryDbContext context)
        {
            DbContext = context;
            Entity = DbContext.Set<TEntity>();
        }

        public virtual async Task<IQueryable<TEntity>> GetAll(IFilter filter = null)
        {
            EnsureDependencies();

            return await SortBy(Entity, filter);

        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            EnsureDependencies();

            return await Entity
                .FirstOrDefaultAsync(entity => entity.Id.Equals(id));
        }

        public virtual async Task Create(TEntity newRecord)
        {
            EnsureDependencies();

            await Entity.AddAsync(newRecord);
        }

        public virtual async Task Update(TEntity exitRecord)
        {
            EnsureDependencies();
            await Task.Run(() =>
            {
                DbContext.Entry(exitRecord).State = EntityState.Modified;
            });
        }

        public virtual async Task Delete(TEntity deleteRecord)
        {
            EnsureDependencies();

            await Task.Run(() =>
            {
                DbContext.Entry(deleteRecord).State = EntityState.Deleted;  
            });
        }

        public void Dispose()
        {
            DbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        #region PRIVATE METHODS

        private void EnsureDependencies()
        {
            if (DbContext == null)
                throw new ArgumentNullException(nameof(DbContext));

            if (Entity == null)
                throw new ArgumentNullException(nameof(Entity));
        }

        #endregion

        #region PROTECTED METHODS

        protected async Task<IQueryable<TEntity>> SortBy(IQueryable<TEntity> records, 
            IFilter filter = null)
        {
            if (records == null)
                throw new ArgumentNullException(nameof(records));

            if (!records.Any()) return records;

            if (filter == null) return records;

            if (string.IsNullOrEmpty(filter.OrderBy) || string.IsNullOrWhiteSpace(filter.OrderBy))
                return records;

            return await Task.FromResult(records.OrderBy(filter));
        }

        protected bool CheckSearchFilter(IFilter filter)
        {
            var filtered = filter != null &&
                (!string.IsNullOrEmpty(filter?.Search) ||
                 !string.IsNullOrWhiteSpace(filter?.Search));

            return filtered;
        }

        #endregion
    }
}
