using Library.Common.Requests.Filters.Abstractions;
using Library.Common.Types;

using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Common.Requests.Filters
{
    public sealed class SectorFilter: BaseFilter
    {
        #region CTOR

        public SectorFilter()
        {
            Ordering = OrderingTypes.ASCENDING;
            OrderBy = "Name";
        }

        #endregion
    }
}
