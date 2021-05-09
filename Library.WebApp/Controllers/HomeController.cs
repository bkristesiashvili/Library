using Library.Data;
using Library.Data.Entities;
using Library.Services.Abstractions;
using Library.WebApp.Controllers.Abstractions;
using Library.WebApp.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WebApp.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        #region CTOR

        public HomeController(IFileLogger logger)
            : base(logger) { }

        #endregion

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
