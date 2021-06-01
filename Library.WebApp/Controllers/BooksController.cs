using Library.Data.Entities;
using Library.Data.Repositories.Abstractions;
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
    public class BooksController : Controller
    {
        #region PRIVATE FIELDS

        #endregion

        #region CTOR

        public BooksController()
        {
        }

        #endregion

        #region ACTIONS

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        #endregion
    }
}
