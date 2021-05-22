using Library.Common;
using Library.Common.Enums;
using Library.Data;
using Library.Data.Entities;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WebApp.Helpers.Extensions
{
    internal static class ApplicationBuilderExtensions
    {
        internal static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder Builder)
        {
            if (Builder == null) throw new ArgumentNullException(nameof(Builder));

            using var scopedService = Builder.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope();

            scopedService.ServiceProvider.GetService<LibraryDbContext>()
                .Database
                .Migrate();

            Task.Run(async () =>
            {
                await SeedSystemUsers(scopedService, GlobalVariables.SystemUserAuthPass);
            })
                .GetAwaiter()
                .GetResult();

            return Builder;
        }

        internal static async Task SeedSystemUsers(IServiceScope scopedService, string adminPassword)
        {
            if (scopedService == null) throw new ArgumentNullException(nameof(scopedService));

            if (string.IsNullOrEmpty(adminPassword) || string.IsNullOrWhiteSpace(adminPassword))
                throw new ArgumentNullException(nameof(adminPassword));

            var userManager = scopedService.ServiceProvider.GetService<UserManager<User>>();

            if (userManager == null) throw new ArgumentNullException(nameof(userManager));

            var systemUser = await userManager.FindByEmailAsync(GlobalVariables.SystemUserAuthEmail);

            if(systemUser == null)
            {
                systemUser = new User
                {
                    Email = GlobalVariables.SystemUserAuthEmail,
                    UserName = GlobalVariables.SystemUserAuthEmail,
                    FirstName = string.Empty,
                    LastName = string.Empty
                };

                var result = await userManager.CreateAsync(systemUser, adminPassword);

                if (!result.Succeeded) throw new OperationCanceledException("System User seed failed!");
            }

            if(systemUser.Id != null)
            {
                var inRole = await userManager
                    .IsInRoleAsync(systemUser, GlobalVariables.DefaultRoles[SystemDefaultRole.SuperAdmin]);

                if (!inRole)
                {
                    var result = await userManager
                        .AddToRoleAsync(systemUser, GlobalVariables.DefaultRoles[SystemDefaultRole.SuperAdmin]);

                    if (!result.Succeeded) 
                        throw new OperationCanceledException("Set the role to the system user failed!");
                }
            }
        }
    }
}
