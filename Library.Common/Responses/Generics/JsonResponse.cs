using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Common.Responses.Generics
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
