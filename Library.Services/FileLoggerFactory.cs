using Library.Services.Abstractions;
using Library.Common.Enums;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services
{
    public sealed class FileLoggerFactory : IFileLogger
    {
        #region CONSTANTS

        private const string EXTENSION = ".log";

        private const string INFO = "INFO";

        private const string ERROR = "ERROR";

        #endregion

        #region PUBLIC PROPERTIES

        public string LogDirectoryPath { get; }

        #endregion

        #region CTOR

        public FileLoggerFactory(string directoryName)
        {
            LogDirectoryPath = directoryName;

            EnsureParameters();
        }

        #endregion

        #region PUBLIC METHODS

        public void Log(string Message, HttpContext httpContext, 
            LoggingTypes loggingType = LoggingTypes.Information)
        {
            using var fileStream = new FileStream(CreateFileLoggerPath(), FileMode.Append);
            using var streamWriter = new StreamWriter(fileStream);

            var messageFormat = FormatMessage(Message, httpContext, loggingType);

            streamWriter.WriteLine(messageFormat);
            streamWriter.Flush();
            streamWriter.Close();
        }

        public async Task LogAsync(string Message, HttpContext httpContext, 
            LoggingTypes loggingType = LoggingTypes.Information)
        {
            using var fileStream = new FileStream(CreateFileLoggerPath(), FileMode.Append);
            using var streamWriter = new StreamWriter(fileStream);

            var messageFormat = FormatMessage(Message, httpContext, loggingType);

            await streamWriter.WriteLineAsync(messageFormat);
            await streamWriter.FlushAsync();
            streamWriter.Close();
        }

        #endregion

        #region PRIVATE METHODS

        private void EnsureParameters()
        {
            if (string.IsNullOrEmpty(LogDirectoryPath) || string.IsNullOrWhiteSpace(LogDirectoryPath))
                throw new ArgumentNullException(nameof(LogDirectoryPath));
        }

        private string CreateFileLoggerPath()
        {
            if (!Directory.Exists(LogDirectoryPath))
                Directory.CreateDirectory(LogDirectoryPath);

            var fileName = $"{DateTime.Now:yyyy-MM-dd}{EXTENSION}";

            var filePath = Path.Combine(LogDirectoryPath, fileName);

            return filePath;
        }

        private string FormatMessage(string message, HttpContext httpContext, 
            LoggingTypes loggingType)
        {
            var formated = loggingType == LoggingTypes.Information ? INFO : ERROR;

            return $"[{DateTime.Now:hh:mm:ss tt}] ({formated}) - (PATH:{httpContext.Request.Path} " +
                   $"| METHOD:{httpContext.Request.Method})" +
                   $"{Environment.NewLine}{message}";
        }

        #endregion
    }
}
