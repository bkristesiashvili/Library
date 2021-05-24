using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Common.Responses
{
    public sealed class ServiceResult
    {
        #region PUBLIC PROPERTIES

        public bool Succeed { get; set; }

        public Exception Error { get; set; }

        #endregion
    }
}
