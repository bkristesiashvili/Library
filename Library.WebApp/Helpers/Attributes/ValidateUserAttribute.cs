using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WebApp.Helpers.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property)]
    public sealed class ValidateUserAttribute :TypeFilterAttribute
    {
        #region CTOR

        public ValidateUserAttribute()
            : base(typeof(UserAuthorizedFilter)) { }

        #endregion
    }
}
