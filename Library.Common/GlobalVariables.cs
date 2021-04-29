using Library.Common.Enums;

using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Common
{
    public static class GlobalVariables
    {
        public static readonly IReadOnlyDictionary<SystemDefaultRoles, string> DefaultRoles =
            new Dictionary<SystemDefaultRoles, string>
            {
                { SystemDefaultRoles.SuperAdmin, "SuperAdmin" },
                { SystemDefaultRoles.Admin, "Admin" },
                { SystemDefaultRoles.User, "User" }
            };
    }
}
