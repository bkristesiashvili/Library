using Library.Common;
using Library.Common.Enums;
using Library.Data.Entities;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Data.Extensions
{
    internal static class ModelBuilderExtensions
    {
        internal static void SeedSystemRoles(this ModelBuilder Builder)
        {
            if (Builder == null) throw new ArgumentNullException(nameof(Builder));

            Builder.Entity<Role>()
                   .HasData(new[]
                   {
                       new Role
                       {
                           Id = Guid.NewGuid(),
                           Name = GlobalVariables.DefaultRoles[SystemDefaultRoles.SuperAdmin],
                           NormalizedName = GlobalVariables.DefaultRoles[SystemDefaultRoles.SuperAdmin]
                           .ToUpper()
                       },
                       new Role
                       {
                           Id = Guid.NewGuid(),
                           Name = GlobalVariables.DefaultRoles[SystemDefaultRoles.Admin],
                           NormalizedName = GlobalVariables.DefaultRoles[SystemDefaultRoles.Admin]
                           .ToUpper()
                       },
                       new Role
                       {
                           Id = Guid.NewGuid(),
                           Name = GlobalVariables.DefaultRoles[SystemDefaultRoles.User],
                           NormalizedName = GlobalVariables.DefaultRoles[SystemDefaultRoles.User]
                           .ToUpper()
                       },

                   });;
        }
    }
}
