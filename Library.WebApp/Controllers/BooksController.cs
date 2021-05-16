using Library.Data.Entities;
using Library.Data.Repositories.Abstractions;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WebApp.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private readonly IRepository<Book> repo;
        #region PRIVATE FIELDS

        #endregion

        #region CTOR

        public BooksController(IRepository<Book> repo)
        {
            this.repo = repo;
        }

        #endregion

        #region ACTIONS

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await repo.GetAll();
            return View(model);
        }

        #endregion
    }
}
