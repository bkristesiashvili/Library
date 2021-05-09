using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Library.WebApp.Helpers.Extensions
{
    public static class ClaimsIdentityExtensions
    {
        #region EXTENSION METHODS

        public static string GetUserId(this ClaimsPrincipal @this)
        {
            if (@this == null)
                throw new ArgumentNullException(nameof(@this));

            return @this.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier)
                .Select(c => c.Value)
                .SingleOrDefault();
        }

        #endregion
    }
}
