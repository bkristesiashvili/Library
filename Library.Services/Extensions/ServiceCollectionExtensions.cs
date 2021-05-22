using Library.Services.Abstractions;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Library.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        #region CONSTANTS

        private const string FACTORY_STRING = "Factory";

        #endregion

        #region EXTENSION METHODS

        public static void AddFileLogger(this IServiceCollection @this, string loggingDirectoryPath)
        {
            if (@this == null)
                throw new ArgumentNullException(nameof(@this));

            if (string.IsNullOrEmpty(loggingDirectoryPath) || string.IsNullOrWhiteSpace(loggingDirectoryPath))
                throw new ArgumentNullException("Empty logging directory name!");

            @this.AddSingleton<IFileLoggerService>(new FileLoggerServiceFactory(loggingDirectoryPath));
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection @this)
        {
            if (@this == null)
                throw new ArgumentNullException(nameof(@this));

            var allServices = Assembly.GetAssembly(typeof(IService))
                .GetTypes()
                .Where(t => t.IsClass && t.GetInterfaces().Contains(typeof(IService)))
                .ToList();

            foreach (var serviceType in allServices)
            {
                var name = serviceType.Name.Replace(FACTORY_STRING, string.Empty);

                var _interface = serviceType.GetInterface($"I{name}");

                if (_interface.Name == nameof(IFileLoggerService)) continue;

                @this.AddScoped(_interface, serviceType);
            }

            return @this;
        }

        #endregion
    }
}
