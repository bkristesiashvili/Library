using static Library.Common.GlobalVariables;

using Library.Common.Requests.Filters;
using Library.Services.Abstractions;
using Library.WebApp.Controllers.Abstractions;
using Library.WebApp.Helpers.Attributes;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Data.Extensions;
using Library.WebApp.Models;
using Library.WebApp.Helpers.Extensions;
using Library.Data.Entities;

namespace Library.WebApp.Controllers
{
    [Authorize]
    [ValidateUser]
    public class SectionsController : BaseController
    {
        #region PRIVATE FIELDS

        private readonly ISectionService sectionService;
        private readonly ISectorService sectorService;

        #endregion

        #region CTOR

        public SectionsController(IFileLoggerService logger,
            ISectionService sectionService,
            ISectorService sectorService)
            : base(logger)
        {
            this.sectionService = sectionService;
            this.sectorService = sectorService;
        }

        #endregion

        #region ACTIONS

        [HttpGet]
        public async Task<IActionResult> IndexAsync([FromQuery] SectionFilter filter)
        {
            if (!User.IsInRole(DefaultRoles[Common.Enums.SystemDefaultRole.SuperAdmin]))
                filter.SelectDeleted = false;

            var sections = from section in await sectionService.GetAllSectionsAsync(filter, filter.SelectDeleted)
                           select new SectionListViewModel
                           {
                               Id = section.Id,
                               Name = section.Name,
                               CreateDate = section.CreatedAt.ToDateString(),
                               IsDeleted = section.DeletedAt.HasValue
                           };

            ViewBag.Search = filter.Search;
            ViewBag.Ordering = filter.Ordering;
            ViewBag.OrderBy = filter.OrderBy;
            ViewBag.SelectDeleted = filter.SelectDeleted;
            ViewBag.PageSize = filter.PageSize;
            ViewBag.Sectors = await sectorService.GetAllSectorsAsync();

            return View(await sections
                .ToPagedListAsync(filter.Page, SectionIndexLink, filter.PageSize));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAsync([FromForm] SectionCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await sectionService.CreateSectionAsync(new Section
                {
                    Name = model.Name,
                    SectorId = model.SectorId
                });

                if (result.Succeed)
                    return JsonResponse(true, SectionCreateSuccessMessage, SectionIndexLink);
            }

            return JsonResponse(false, SectionCreateFaieldMessage);
        }

        #endregion
    }
}
