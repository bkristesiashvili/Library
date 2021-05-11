using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Common.Collections
{
    public sealed class PagedList<TObject> : List<TObject>
        where TObject: class
    {
        #region PUBLIC PROPERTIES

        public int TotalPages { get; private set; }

        public int PageNumber { get; private set; }

        public bool Previous => (PageNumber > 1);

        public bool Next => (PageNumber < TotalPages);

        #endregion

        #region CTOR

        private PagedList(IList<TObject> data, int count, int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber;
            this.TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            this.AddRange(data);
        }

        #endregion

        #region PUBLIC STATIC METHODS

        public static async Task<PagedList<TObject>> CreatePagedListAsync(
            IQueryable<TObject> data, 
            int pageNumber, 
            int pageSize = 15)
        {
            var count = await Task.FromResult(data.Count());
            var items = await Task.FromResult(CollectionPagination(data, pageNumber, pageSize));



            return new PagedList<TObject>(items, count, pageNumber, pageSize);
        }

        #endregion

        #region PRIVATE METHODS

        private static IList<TObject> CollectionPagination(IQueryable<TObject> data, int pageNumber, int pageSize)
        {
            return data.Skip((pageNumber - 1) * pageSize)
                       .Take(pageSize)
                       .ToList();
        }

        #endregion
    }
}
