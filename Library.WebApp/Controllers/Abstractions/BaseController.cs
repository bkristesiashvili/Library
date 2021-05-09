using Library.Services.Abstractions;
using Library.Common.Enums;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WebApp.Controllers.Abstractions
{
    public abstract class BaseController : Controller
    {
        #region PROTECTED PROPERTIES

        protected IFileLogger Logger { get; }

        #endregion

        #region CTOR

        public BaseController(IFileLogger loger)
            => this.Logger = loger;

        #endregion

        #region OVERRIDED METHODS

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
                Logger.Log(context.Exception.ToString(), context.HttpContext, LoggingTypes.Error);
            base.OnActionExecuted(context);
        }

        #endregion
    }
}
