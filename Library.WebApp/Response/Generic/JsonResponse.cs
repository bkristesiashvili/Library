using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WebApp.Response.Generic
{
    public sealed class JsonResponse<TObject> : JsonResponse
        where TObject : class
    {
        #region PROPERTIES

        public IList<TObject> Data { get; set; }

        #endregion

        #region CTOR

        public JsonResponse()
            : base()
        {
            Data = new List<TObject>();
        }

        #endregion
    }
}
