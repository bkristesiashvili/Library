using Library.Common.Requests.Filters;
using Library.Data.Entities;
using Library.Data.Extensions;
using Library.Services.Abstractions;
using Library.WebApp.Controllers.Abstractions;
using Library.WebApp.Helpers.Extensions;
using Library.WebApp.Models;

using static Library.Common.GlobalVariables;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WebApp.Controllers
{
    public class SectorsController : BaseController
    {
        #region PRIVATE FIELDS

        private readonly ISectorService sectorService;

        #endregion

        #region CTOR

        public SectorsController(IFileLoggerService logger,
            ISectorService sectorService)
            : base(logger)
        {
            this.sectorService = sectorService;
        }

        #endregion

        #region ACTIONS

        [HttpGet]
        public async Task<IActionResult> IndexAsync([FromQuery] SectorFilter filter)
        {
            var sectors = from sector in await sectorService.GetAllSectorsAsync(filter)
                          select new SectorListViewModel
                          {
                              Id = sector.Id,
                              Name = sector.Name,
                              CreateDate = sector.CreatedAt.ToDateString()
                          };

            ViewBag.Search = filter.Search;
            ViewBag.Ordering = filter.Ordering;
            ViewBag.OrderBy = filter.OrderBy;

            return View(await sectors.ToPagedListAsync(filter.Page, filter.PageSize));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAsync([FromForm] SectorCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await sectorService.CreateSectorAsync(new Sector
                {
                    Name = model.Name
                });

                if (result.Succeed)
                    return JsonResponse(true, SectorCreateSuccessMessage, SectorIndexLink);
            }

            return JsonResponse(false, SectorCreateFaieldMessage);
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync([FromForm]SectorEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await sectorService.UpdateSectorAsync(model.Id, new Sector
                {
                    Name = model.Name
                });

                if (result.Succeed)
                    return JsonResponse(true, SectorEditSuccessMessage, SectorIndexLink);
            }

            return JsonResponse(false, SectorEditFailedMessage);
        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAsync([FromForm]Guid id)
        {
            var result = await sectorService.DeleteSectorAsync(id);

            if (result.Succeed)
                return JsonResponse(true, SectorDeleteSuccessMessage, SectorIndexLink);

            return JsonResponse(false, SectorDeleteFailedMessage);
        }

        #endregion
    }
}
