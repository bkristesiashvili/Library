using Library.Common.Enums;

using Microsoft.AspNetCore.Http;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Abstractions
{
    public interface IFileLoggerService : IService
    {
        #region PROPERTIES

        string LogDirectoryPath { get; }

        #endregion

        #region METHODS

        void Log(string Message, HttpContext httpCOntext, LoggingType loggingType = LoggingType.Information);

        Task LogAsync(string Message, HttpContext httpCOntext, LoggingType loggingType = LoggingType.Information);

        #endregion
    }
}
