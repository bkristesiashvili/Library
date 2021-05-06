using Library.Services.Abstractions;

using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        #region EXTENSION METHODS

        public static void AddFileLogger(this IServiceCollection @this, string loggingDirectoryPath)
        {
            if (@this == null)
                throw new ArgumentNullException(nameof(@this));

            if (string.IsNullOrEmpty(loggingDirectoryPath) || string.IsNullOrWhiteSpace(loggingDirectoryPath))
                throw new ArgumentNullException("Empty logging directory name!");

            @this.AddSingleton<IFileLogger>(new FileLoggerFactory(loggingDirectoryPath));
        }

        #endregion
    }
}
