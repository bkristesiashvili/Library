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

        public IActionResult Index()
        {
            sectorService.DeleteSectorAsync(new Library.Data.Entities.Sector
            {
                Name = "test"
            });

            return View();
        }

        #endregion
    }
}
