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
    public sealed class SectionsRepository : BaseRepository<Section>
    {
        #region CTOR

        public SectionsRepository(LibraryDbContext context)
            : base(context) { }

        #endregion

        #region OVERRIDED METHODS

        public override async Task<IQueryable<Section>> GetAll(IFilter filter = null)
        {
            var sections = await base.GetAll(filter);

            return CheckSearchFilter(filter)
                ? from sector in sections
                  where sector.Name.StartsWith(filter.Search)
                  select sector
                : sections;
        }

        #endregion
    }
}
