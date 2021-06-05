using Library.Common.Requests.Filters.Abstractions;
using Library.Common.Types;

using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Common.Requests.Filters
{
    public sealed class AuthorFilter : BaseFilter
    {
        #region PUBLIC PROPERTIES

        public bool Checked { get; set; }

        #endregion

        #region CTOR

        public AuthorFilter()
        {
            Ordering = OrderingTypes.ASCENDING;
            OrderBy = "FirstName";
            Checked = false;
        }

        #endregion
    }
}
