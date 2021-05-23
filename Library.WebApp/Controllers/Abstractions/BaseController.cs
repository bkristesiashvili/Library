﻿using Library.Services.Abstractions;
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
                Logger.Log(context.Exception.ToString(), context.HttpContext, LoggingType.Error);
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
