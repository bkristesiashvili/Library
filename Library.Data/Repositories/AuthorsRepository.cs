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
    public sealed class AuthorsRepository : BaseRepository<Author>
    {
        #region CTOR

        public AuthorsRepository(LibraryDbContext context)
            : base(context) { }

        #endregion

        #region OVERRIDED METHODS

        public override async Task<IQueryable<Author>> GetAll(IFilter filter = null)
        {
            var authors = await base.GetAll(filter);

            return CheckSearchFilter(filter)
                ? from author in authors
                  where author.FirstName.StartsWith(filter.Search) ||
                        author.MiddleName.StartsWith(filter.Search) ||
                        author.LastName.StartsWith(filter.Search)
                  select author
                : authors;
        }

        #endregion
    }
}
