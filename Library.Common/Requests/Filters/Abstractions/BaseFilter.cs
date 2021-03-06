using Library.Common.Types;

using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Common.Requests.Filters.Abstractions
{
    public abstract class BaseFilter : IFilter
    {
        #region CONSTANTS

        private const int MIN_PAGE_NUM = 1;
        private const int MIN_PAGE_SIZE = 5;
        private const int MAX_PAGE_SIZE = 50;

        #endregion

        #region PRIVATE FIELDS

        private int _pageNumber = MIN_PAGE_NUM;

        private int _pageSize = MIN_PAGE_SIZE;

        private DateTime _from = DateTime.MinValue;

        private DateTime _to = DateTime.MinValue;

        #endregion

        #region PUBLIC PROPERTIES

        public string Search { get; set; }

        public string OrderBy { get; set; }

        public string Ordering { get; set; }

        public int Page
        {
            get => _pageNumber;
            set
            {
                _pageNumber = value < MIN_PAGE_NUM ? MIN_PAGE_NUM : value;
            }
        }

        public int PageSize
        {
            get => _pageSize;
            set
            {
                _pageSize = value < MIN_PAGE_SIZE
                    ? MIN_PAGE_SIZE
                    : value > MAX_PAGE_SIZE
                    ? MAX_PAGE_SIZE
                    : value;
            }
        }

        public DateTime From
        {
            get => _from;
            set
            {
                if (value > DateTime.Now)
                    _from = DateTime.Now;
                else
                    _from = value;
            }
        }

        public DateTime To
        {
            get => _to;
            set
            {
                if (value > DateTime.Now)
                    _to = DateTime.Now;
                else
                    _to = value;
            }
        }

        #endregion

        #region CTOR

        public BaseFilter()
        {
            Ordering = OrderingTypes.ASCENDING;
            OrderBy = "CreatedAt";
        }

        #endregion
    }
}
