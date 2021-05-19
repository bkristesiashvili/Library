using Library.Common.Requests.Filters.Abstractions;
using Library.Common.Types;

using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Common.Requests.Filters
{
    public sealed class CustomerFilter : BaseFilter
    {
        #region CTOR

        public CustomerFilter()
        {
            OrderBy = "FirstName";
            Ordering = OrderingTypes.ASCENDING;
        }

        #endregion
    }
}
