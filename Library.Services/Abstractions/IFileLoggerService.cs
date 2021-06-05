using Library.Common.Enums;
using Library.Common.Requests.Filters.Abstractions;
using Library.Common.Responses;
using Library.Data.Entities;

using Microsoft.AspNetCore.Http;

using System;
using System.Collections.Generic;
using System.Linq;
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

        void FileLog(string Message, HttpContext httpCOntext, LoggingType loggingType = LoggingType.Information);

        Task FileLogAsync(string Message, HttpContext httpCOntext, LoggingType loggingType = LoggingType.Information);

        Task<IQueryable<SystemError>> GetAllSystemErrorsAsync(IFilter filter = null);

        Task<SystemError> GetSystemErrorByIdAsync(Guid id);

        Task<ServiceResult> CreateSystemErrorLogAsync(SystemError newSystemError);

        Task<ServiceResult> ResolveSystemErrorAsync(Guid id);

        #endregion
    }
}
