using static Library.Common.GlobalVariables;

using Library.Common.Requests.Filters;
using Library.Data.Extensions;
using Library.Services.Abstractions;
using Library.WebApp.Controllers.Abstractions;
using Library.WebApp.Models;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.WebApp.Helpers.Extensions;

namespace Library.WebApp.Controllers
{
    public class BookShelvesController : BaseController
    {
        #region PRIVATE FIELDS

        private readonly IBookShelveService bookShelveService;

        #endregion

        #region CTOR

        public BookShelvesController(IFileLoggerService logger,
            IBookShelveService bookShelveService)
            : base(logger)
        {
            this.bookShelveService = bookShelveService;
        }

        #endregion

        #region ACTIONS

        [HttpGet]
        public async Task<IActionResult> IndexAsync([FromQuery] BookShelveFIlter filter)
        {
            var shelves = from shelve in await bookShelveService.GetAllBookShelveAsync(filter, filter.SelectDeleted)
                          select new BookShelveListViewModel
                          {
                              Id = shelve.Id,
                              Name = shelve.Name,
                              SectionId = shelve.SectionId,
                              SectionName = shelve.Section.Name,
                              CreateDate = shelve.CreatedAt.ToDateString(),
                              IsDeleted = shelve.DeletedAt.HasValue
                          };

            ViewBag.Search = filter.Search;
            ViewBag.Ordering = filter.Ordering;
            ViewBag.OrderBy = filter.OrderBy;
            ViewBag.SelectDeleted = filter.SelectDeleted;
            ViewBag.PageSize = filter.PageSize;

            return View(await shelves.ToPagedListAsync(filter.Page, BookShelveIndexLink, filter.PageSize));
        }

        public IActionResult Add()
        {
            return JsonResponse(false, "");
        }

        public IActionResult Edit()
        {
            return JsonResponse(false, "");
        }

        public IActionResult Delete()
        {
            return JsonResponse(false, "");
        }

        public IActionResult Restore()
        {
            return JsonResponse(false, "");
        }

        #endregion
    }
}
