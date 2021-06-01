using Library.Services.Abstractions;
using Library.WebApp.Controllers.Abstractions;
using Library.WebApp.Helpers.Attributes;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WebApp.Controllers
{
    [Authorize]
    [ValidateUser]
    public class SectionsController : BaseController
    {
        #region CTOR

        public SectionsController(IFileLoggerService logger)
            : base(logger)
        {

        }

        #endregion

        #region ACTIONS

        public IActionResult Index()
        {
            return View();
        }

        #endregion
    }
}
