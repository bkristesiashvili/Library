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
    public class AuthorsController : BaseController
    {
        #region PRIVATE FIELDS

        private readonly IAuthorService authorService;

        #endregion

        #region CTOR

        public AuthorsController(IFileLoggerService logger, IAuthorService authorService)
            : base(logger)
        {
            this.authorService = authorService;
        }

        #endregion

        #region ACTIONS

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        #endregion
    }
}
