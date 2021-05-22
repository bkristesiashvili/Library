using Library.Common.Requests.Filters;
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

            return View(await authors.ToPagedListAsync(filter.Page, filter.PageSize));
        }

        #endregion
    }
}
