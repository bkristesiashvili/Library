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
using Microsoft.AspNetCore.Authorization;
using Library.WebApp.Helpers.Attributes;
using Library.Data.Entities;
using Library.Common.Extensions;

namespace Library.WebApp.Controllers
{
    [Authorize]
    [ValidateUser]
    public class BookShelvesController : BaseController
    {
        #region PRIVATE FIELDS

        private readonly IBookShelveService bookShelveService;
        private readonly ISectionService sectionService;

        #endregion

        #region CTOR

        public BookShelvesController(IFileLoggerService logger,
            IBookShelveService bookShelveService,
            ISectionService sectionService)
            : base(logger)
        {
            this.bookShelveService = bookShelveService;
            this.sectionService = sectionService;
        }

        #endregion

        #region ACTIONS

        [HttpGet]
        public async Task<IActionResult> IndexAsync([FromQuery] BookShelveFIlter filter)
        {
            var shelves = from shelve in await bookShelveService.GetAllBookShelveAsync(filter, filter.Checked)
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
            ViewBag.SelectDeleted = filter.Checked;
            ViewBag.PageSize = filter.PageSize;
            ViewBag.Sections = await sectionService.GetAllSectionsAsync();

            return View(await shelves.ToPagedListAsync(filter.Page, BookShelveIndexLink, filter.PageSize));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAsync([FromForm] BookShelveCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await bookShelveService.CreateBookShelveAsync(new BookShelve
                {
                    Name = model.Name,
                    SectionId = model.SectionId
                });

                if (result.Succeed)
                    return JsonResponse(true, BookSHelveCreateSuccessMessage, BookShelveIndexLink);
            }

            return JsonResponse(false, BookSHelveCreateFaieldMessage);
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
