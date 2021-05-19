using Library.Common.Requests.Filters.Abstractions;
using Library.Common.Types;

using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Common.Requests.Filters
{
    public sealed class AccountFilter : BaseFilter
    {
        #region CTOR

        public AccountFilter()
        {
            Ordering = OrderingTypes.ASCENDING;
            OrderBy = "FirstName";
        }

        #endregion
    }
}
