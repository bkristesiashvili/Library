using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WebApp.Response
{
    public class JsonResponse
    {
        #region PROPERTIES

        public string Message { get; set; }

        public bool Succeed { get; set; }

        public string ReturnUrl { get; set; }

        #endregion

        #region CTOR

        public JsonResponse()
        {
            Message = string.Empty;
            Succeed = false;
            ReturnUrl = string.Empty;
        }

        #endregion
    }
}
