using Library.Common.Requests.Filters.Abstractions;
using Library.Data.Entities;
using Library.Data.Repositories.Abstractions;

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Repositories
{
    public sealed class GenresRepository : BaseRepository<Genre>
    {
        #region CTOR

        public GenresRepository(LibraryDbContext context)
            : base(context) { }

        #endregion

        #region OVERRIDED METHODS

        public override async Task<IQueryable<Genre>> GetAll(IFilter filter = null)
        {
            var genres = await base.GetAll(filter);

            return CheckSearchFilter(filter)
                ? from genre in genres
                  where genre.Name.StartsWith(filter.Search)
                  select genre
                : genres;
        }

        public override async Task<Genre> GetByIdAsync(Guid id)
        {
            EnsureDependencies();

            return await Entity.Include(s => s.Books)
                .SingleOrDefaultAsync(s => s.Id.Equals(id));
        }

        #endregion
    }
}
