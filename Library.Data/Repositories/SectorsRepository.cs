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
    public sealed class SectorsRepository : BaseRepository<Sector>
    {
        #region CTOR

        public SectorsRepository(LibraryDbContext context)
            : base(context) { }

        #endregion

        #region OVERRIDED METHODS

        public override async Task<IQueryable<Sector>> GetAll(IFilter filter = null)
        {
            var sectors = await base.GetAll(filter);

            return CheckSearchFilter(filter)
                ? from sector in sectors
                  where sector.Name.StartsWith(filter.Search)
                  select sector
                : sectors;
        }

        public override async Task<Sector> GetByIdAsync(Guid id)
        {
            EnsureDependencies();

            return await Entity.Include(s => s.Sections)
                .SingleOrDefaultAsync(s => s.Id.Equals(id));
        }

        #endregion
    }
}
