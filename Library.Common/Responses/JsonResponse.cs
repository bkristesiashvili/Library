using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Common.Responses
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
