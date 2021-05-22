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
                           Name = GlobalVariables.DefaultRoles[SystemDefaultRole.SuperAdmin],
                           NormalizedName = GlobalVariables.DefaultRoles[SystemDefaultRole.SuperAdmin]
                           .ToUpper()
                       },
                       new Role
                       {
                           Id = Guid.NewGuid(),
                           Name = GlobalVariables.DefaultRoles[SystemDefaultRole.Admin],
                           NormalizedName = GlobalVariables.DefaultRoles[SystemDefaultRole.Admin]
                           .ToUpper()
                       },
                       new Role
                       {
                           Id = Guid.NewGuid(),
                           Name = GlobalVariables.DefaultRoles[SystemDefaultRole.User],
                           NormalizedName = GlobalVariables.DefaultRoles[SystemDefaultRole.User]
                           .ToUpper()
                       },

                   });;
        }
    }
}
