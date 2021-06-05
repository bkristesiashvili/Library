using Library.Common.Requests.Filters.Abstractions;
using Library.Data.Entities;
using Library.Data.Repositories.Abstractions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Repositories
{
    public sealed class SystemErrorRepository : BaseRepository<SystemError>
    {
        #region CTOR

        public SystemErrorRepository(LibraryDbContext context)
            :base(context) { }

        #endregion

        #region OVERRIDED METHODS

        public override async Task<IQueryable<SystemError>> GetAll(IFilter filter = null)
        {
            var errors = await base.GetAll(filter);

            return CheckSearchFilter(filter)
                ? from error in errors
                  where error.LogType.StartsWith(filter.Search) ||
                        (error.LogDate >= filter.From && error.LogDate <= filter.To) ||
                        error.LogText.StartsWith(filter.Search)
                  select error
                : errors;
        }

        #endregion
    }
}
