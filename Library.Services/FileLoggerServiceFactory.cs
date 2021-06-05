using static Library.Common.GlobalVariables;

using Library.Services.Abstractions;
using Library.Common.Enums;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Library.Data.Repositories.Uow.Abstractions;
using Microsoft.Extensions.Configuration;
using System.Linq;
using Library.Data.Entities;
using Library.Common.Requests.Filters.Abstractions;
using Library.Common.Responses;

namespace Library.Services
{
    public sealed class FileLoggerServiceFactory : BaseService, IFileLoggerService
    {
        #region CONSTANTS

        private const string EXTENSION = ".log";

        private const string INFO = "INFO";

        private const string ERROR = "ERROR";

        private const string DEFAULT_DIR = "Logs";


        #endregion

        #region PUBLIC PROPERTIES

        public string LogDirectoryPath { get; }

        #endregion

        #region CTOR

        public FileLoggerServiceFactory(IUnitOfWorks uow, IConfiguration config)
            : base(uow)
        {
            LogDirectoryPath = config == null
                ? DEFAULT_DIR
                : config.GetSection("FileLogger:Dir").Value;

            EnsureDependencies();
        }

        #endregion

        #region PUBLIC METHODS

        public void FileLog(string Message, HttpContext httpContext,
            LoggingType loggingType = LoggingType.Information)
        {
            using var fileStream = new FileStream(CreateFileLoggerPath(), FileMode.Append);
            using var streamWriter = new StreamWriter(fileStream);

            var messageFormat = FormatMessage(Message, httpContext, loggingType);

            streamWriter.WriteLine(messageFormat);
            streamWriter.Flush();
            streamWriter.Close();
        }

        public async Task FileLogAsync(string Message, HttpContext httpContext,
            LoggingType loggingType = LoggingType.Information)
        {
            using var fileStream = new FileStream(CreateFileLoggerPath(), FileMode.Append);
            using var streamWriter = new StreamWriter(fileStream);

            var messageFormat = FormatMessage(Message, httpContext, loggingType);

            await streamWriter.WriteLineAsync(messageFormat);
            await streamWriter.FlushAsync();
            streamWriter.Close();
        }


        public async Task<IQueryable<SystemError>> GetAllSystemErrorsAsync(IFilter filter = null,
            bool selectResolved = false)
        {
            EnsureDependencies();

            var errors = await UnitOfWorks.SystemErrorRepository.GetAll(filter);

            return from error in errors
                   where error.Resolved == selectResolved
                   select error;
        }

        public async Task<SystemError> GetSystemErrorByIdAsync(Guid id)
        {
            EnsureDependencies();

            return await UnitOfWorks.SystemErrorRepository.GetByIdAsync(id);
        }

        public async Task<ServiceResult> CreateSystemErrorLogAsync(SystemError newSystemError)
        {
            try
            {
                EnsureDependencies();

                await UnitOfWorks.SystemErrorRepository.CreateAsync(newSystemError);
                UnitOfWorks.SaveChanges();

                return ServiceResult(true);
            }
            catch (Exception e)
            {
                return ServiceResult(false, e);
            }
        }

        public async Task<ServiceResult> ResolveSystemErrorAsync(Guid id, string comment = default)
        {
            try
            {
                EnsureDependencies();

                var error = await GetSystemErrorByIdAsync(id);

                if (error == null)
                    throw new Exception(RecordNotFound);

                error.Resolved = true;

                if (!string.IsNullOrEmpty(comment) || !string.IsNullOrWhiteSpace(comment))
                    error.Comment = comment;

                await UnitOfWorks.SystemErrorRepository.UpdateAsync(error);
                UnitOfWorks.SaveChanges();

                return ServiceResult(true);
            }
            catch (Exception e)
            {
                return ServiceResult(false, e);
            }
        }

        public void Dispose() => GC.Collect();

        #endregion

        #region PROTECTED METHODS

        protected override void EnsureDependencies()
        {
            if (string.IsNullOrEmpty(LogDirectoryPath) || string.IsNullOrWhiteSpace(LogDirectoryPath))
                throw new ArgumentNullException(nameof(LogDirectoryPath));

            if (UnitOfWorks == null)
                throw new ArgumentNullException(UOW_ExceptionMessage);
        }

        #endregion

        #region PRIVATE METHODS

        private string CreateFileLoggerPath()
        {
            if (!Directory.Exists(LogDirectoryPath))
                Directory.CreateDirectory(LogDirectoryPath);

            var fileName = $"{DateTime.Now:yyyy-MM-dd}{EXTENSION}";

            var filePath = Path.Combine(LogDirectoryPath, fileName);

            return filePath;
        }

        private string FormatMessage(string message, HttpContext httpContext,
            LoggingType loggingType)
        {
            var formated = loggingType == LoggingType.Information ? INFO : ERROR;

            return $"[{DateTime.Now:hh:mm:ss tt}] ({formated}) - (PATH:{httpContext.Request.Path} " +
                   $"| METHOD:{httpContext.Request.Method})" +
                   $"{Environment.NewLine}{message}";
        }

        #endregion
    }
}
