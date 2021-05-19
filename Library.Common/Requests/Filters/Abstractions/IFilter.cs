using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Common.Requests.Filters.Abstractions
{
    public interface IFilter
    {
        #region PROPERTIES

        string Search { get; set; }

        string OrderBy { get; set; }

        string Ordering { get; set; }

        #endregion
    }
}
