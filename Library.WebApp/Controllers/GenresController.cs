using Library.Services.Abstractions;
using Library.WebApp.Controllers.Abstractions;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WebApp.Controllers
{
    [Authorize]
    public class GenresController : BaseController
    {
        #region CTOR

        public GenresController(IFileLoggerService logger)
            : base(logger) { }

        #endregion

        #region ACTIONS

        public IActionResult Index()
        {
            return View();
        }

        #endregion
    }
}
