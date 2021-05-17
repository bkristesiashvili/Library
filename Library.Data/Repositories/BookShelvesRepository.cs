using Library.Data.Entities;
using Library.Data.Repositories.Abstractions;
using Library.Data.Request.Filters.Abstractions;

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

        #endregion
    }
}
