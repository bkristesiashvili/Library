using Library.Common.Requests.Filters.Abstractions;
using Library.Data.Entities;
using Library.Data.Repositories.Abstractions;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Repositories
{
    public sealed class BookShelvesRepository : BaseRepository<BookShelve>
    {
        #region CTOR

        public BookShelvesRepository(LibraryDbContext context)
            : base(context) { }

        #endregion

        #region OVERRIDED METHODS

        public override async Task<IQueryable<BookShelve>> GetAll(IFilter filter = null)
        {
            var shelves = await base.GetAll(filter);

            return CheckSearchFilter(filter)
                ? from shelve in shelves
                  where shelve.Name.StartsWith(filter.Search)
                  select shelve
                : shelves;
        }

        public override async Task<BookShelve> GetByIdAsync(Guid id)
        {
            EnsureDependencies();

            return await Entity.Include(s => s.Books)
                .SingleOrDefaultAsync(s => s.Id.Equals(id));
        }

        #endregion
    }
}
