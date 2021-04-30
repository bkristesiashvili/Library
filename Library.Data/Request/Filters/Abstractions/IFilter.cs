using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Data.Request.Filters.Abstractions
{
    public interface IFilter
    {
        string Search { get; set; }

        string OrderBy { get; set; }

        string Ordering { get; set; }
    }
}
