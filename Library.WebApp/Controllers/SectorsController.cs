using Library.Common.Requests.Filters;
using Library.Data.Extensions;
using Library.Services.Abstractions;
using Library.WebApp.Controllers.Abstractions;

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
                          select sector;

            return View(await sectors.ToPagedListAsync(filter.Page, filter.PageSize));
        }

        #endregion
    }
}
