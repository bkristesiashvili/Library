using Library.Common.Types;
using Library.Data.Request.Filters.Abstractions;

using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Data.Request.Filters
{
    public sealed class AccountFilter : IFilter
    {
        #region PUBLIC PROPERTIES

        public string Search { get ; set ; }

        public string OrderBy { get ; set ; }

        public string Ordering { get ; set ; }

        #endregion

        #region CTOR

        public AccountFilter()
        {
            Ordering = OrderingTypes.ASCENDING;
            OrderBy = "firstname";
        }

        #endregion
    }
}
