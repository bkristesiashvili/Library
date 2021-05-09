using Library.Common.Enums;

using Microsoft.AspNetCore.Http;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Abstractions
{
    public interface IFileLogger
    {
        #region PROPERTIES

        string LogDirectoryPath { get; }

        #endregion

        #region METHODS

        void Log(string Message, HttpContext httpCOntext, LoggingTypes loggingType = LoggingTypes.Information);

        Task LogAsync(string Message, HttpContext httpCOntext, LoggingTypes loggingType = LoggingTypes.Information);

        #endregion
    }
}
