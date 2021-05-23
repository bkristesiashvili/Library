using Library.Common.Requests.Filters;
using Library.Common.Responses;
using Library.Data.Entities;
using Library.Data.Extensions;
using Library.Services.Abstractions;
using Library.WebApp.Controllers.Abstractions;
using Library.WebApp.Models;

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
        public async Task<IActionResult> IndexAsync([FromQuery]AuthorFilter filter)
        {
            var authors = from author in await authorService.GetAllAuthorsAsync(filter)
                          select new AuthorListViewModel
                          {
                              FirstName = author.FirstName,
                              Middlename = author.MiddleName,
                              LastName = author.LastName
                          };

            ViewBag.Search = filter.Search;
            ViewBag.Ordering = filter.Ordering;
            ViewBag.OrderBy = filter.OrderBy;

            return View(await authors.ToPagedListAsync(filter.Page, filter.PageSize));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAsync([FromForm]AuthorCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await authorService.CreateNewAuthorAsync(new Author
                {
                    FirstName = model.FirstName,
                    MiddleName = model.MiddleName,
                    LastName = model.LastName
                });

                if (!result.Succeed)
                    return JsonResponse(false, "eror");

                return JsonResponse(true, "daemata", "/authors");
            }

            return JsonResponse(false, "error");
        }

        #endregion
    }
}
