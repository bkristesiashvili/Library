using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WebApp.Helpers.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property)]
    public sealed class ValidUserAttribute :TypeFilterAttribute
    {
        #region CTOR

        public ValidUserAttribute()
            : base(typeof(UserAuthorizedFilter)) { }

        #endregion
    }
}
