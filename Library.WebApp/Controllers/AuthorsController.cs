using static Library.Common.GlobalVariables;

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
using Library.WebApp.Helpers.Attributes;

namespace Library.WebApp.Controllers
{
    [Authorize]
    [ValidateUser]
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
        public async Task<IActionResult> IndexAsync([FromQuery] AuthorFilter filter)
        {
            if (!User.IsInRole(DefaultRoles[Common.Enums.SystemDefaultRole.SuperAdmin]))
                filter.SelectDeleted = false;

            var authors = from author in await authorService.GetAllAuthorsAsync(filter, filter.SelectDeleted)
                          select new AuthorListViewModel
                          {
                              Id = author.Id,
                              FirstName = author.FirstName,
                              Middlename = author.MiddleName,
                              LastName = author.LastName,
                              IsDeleted = author.DeletedAt.HasValue
                          };

            ViewBag.Search = filter.Search;
            ViewBag.Ordering = filter.Ordering;
            ViewBag.OrderBy = filter.OrderBy;
            ViewBag.SelectDeleted = filter.SelectDeleted;
            ViewBag.PageSize = filter.PageSize;

            return View(await authors.ToPagedListAsync(filter.Page, AuthorIndexLink, filter.PageSize));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAsync([FromForm] AuthorCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await authorService.CreateNewAuthorAsync(new Author
                {
                    FirstName = model.FirstName,
                    MiddleName = model.MiddleName,
                    LastName = model.LastName
                });

                if (result.Succeed)
                    return JsonResponse(true, AuthorCreatedSuccessMessage, AuthorIndexLink);
            }

            return JsonResponse(false, AuthorCreateFailedMessage);
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync([FromForm] AuthorEditViewModel model)
        {
            if(ModelState.IsValid)
            {
                var result = await authorService.EditAuthorInfoAsync(model.Id, new Author
                {
                    FirstName = model.FirstName,
                    MiddleName = model.MiddleName,
                    LastName = model.LastName
                });

                if (result.Succeed)
                    return JsonResponse(true, AuthorEditSuccessMessage, AuthorIndexLink);
            }

            return JsonResponse(false, AuthorEditFailedMessage);
        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAsync([FromForm] Guid id)
        {
            var result = await authorService.DeleteAuthorInfoAsync(id, Common.Enums.DeletionType.Soft);

            if (result.Succeed)
                return JsonResponse(true, AuthorDeletedSuccessMessage, AuthorIndexLink);
            return JsonResponse(false, AuthorDeleteFailedMessage);
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RestoreAsync([FromForm]Guid id)
        {
            var result = await authorService.RestoreAuthorAsync(id);

            if (result.Succeed)
                return JsonResponse(true, AuthorRestoreSuccessMessage, AuthorIndexLink);

            return JsonResponse(false, AuthorRestoreFailedMessage);
        }

        #endregion
    }
}
