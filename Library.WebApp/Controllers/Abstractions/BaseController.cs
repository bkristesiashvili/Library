using Library.Services.Abstractions;
using Library.Common.Enums;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Common.Responses;

namespace Library.WebApp.Controllers.Abstractions
{
    public abstract class BaseController : Controller
    {
        #region PROTECTED PROPERTIES

        protected IFileLoggerService Logger { get; }

        #endregion

        #region CTOR

        public BaseController(IFileLoggerService logger)
            => this.Logger = logger;

        #endregion

        #region OVERRIDED METHODS

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                Logger.FileLog(context.Exception.ToString(), context.HttpContext, LoggingType.Error);
                Logger.CreateSystemErrorLogAsync(new Data.Entities.SystemError
                {
                    LogType = LoggingType.Error.ToString(),
                    LogDate = DateTime.Now,
                    LogText = context.Exception.ToString(),
                    RequestMethod = context.HttpContext.Request.Method,
                    RequestPath = context.HttpContext.Request.Path,
                    Resolved = false
                });
            }
            base.OnActionExecuted(context);
        }

        #endregion

        #region PROTECTED METHODS

        public JsonResult JsonResponse(bool succeed = false, 
            string message = default, 
            string returnUrl = default)
        {
            return Json(new JsonResponse
            {
                Succeed = succeed,
                Message = message,
                ReturnUrl = returnUrl
            });
        }

        #endregion
    }
}
