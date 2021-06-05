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
    public sealed class BooksRepository : BaseRepository<Book>
    {
        #region CTOR

        public BooksRepository(LibraryDbContext context)
            : base(context) { }

        #endregion

        #region OVERRIDED METHODS

        public override async Task<IQueryable<Book>> GetAll(IFilter filter = null)
        {
            var results = await base.GetAll(filter);

            return CheckSearchFilter(filter)
                ? from record in results
                  join authoredBy in DbContext.AuthoredBooks
                  on record.Id equals authoredBy.BookId
                  where record.ISBN.StartsWith(filter.Search) ||
                        record.Title.StartsWith(filter.Search) ||
                        authoredBy.Author.FirstName.StartsWith(filter.Search) ||
                        authoredBy.Author.MiddleName.StartsWith(filter.Search) ||
                        authoredBy.Author.LastName.StartsWith(filter.Search)
                  select record
                : results;
        }

        public override async Task<Book> GetByIdAsync(Guid id)
        {
            EnsureDependencies();

            return await Entity.Include(s => new { s.Genres, s.BookShelves, s.Customers })
                .SingleOrDefaultAsync(s => s.Id.Equals(id));
        }

        #endregion
    }
}
