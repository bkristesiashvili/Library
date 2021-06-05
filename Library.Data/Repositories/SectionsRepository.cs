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
    public sealed class SectionsRepository : BaseRepository<Section>
    {
        #region CTOR

        public SectionsRepository(LibraryDbContext context)
            : base(context) { }

        #endregion

        #region OVERRIDED METHODS

        public override async Task<IQueryable<Section>> GetAll(IFilter filter = null)
        {
            var sections = await SortBy(Entity.Include(S => S.Sector), filter);

            return CheckSearchFilter(filter)
                ? from sector in sections
                  where sector.Name.StartsWith(filter.Search)
                  select sector
                : sections;
        }

        public override async Task<Section> GetByIdAsync(Guid id)
        {
            EnsureDependencies();

            return await Entity.Include(s => s.BookShelves)
                .SingleOrDefaultAsync(s => s.Id.Equals(id));
        }

        #endregion
    }
}
