using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WebApp.Models
{
    public sealed class FilterViewModel
    {
        #region PUBLIC PROPERTIES

        public string Url { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }

        public string Search { get; set; }

        public bool SelectDeleted { get; set; }

        public string OrderBy { get; set; }

        public string Ordering { get; set; }

        #endregion
    }
}
