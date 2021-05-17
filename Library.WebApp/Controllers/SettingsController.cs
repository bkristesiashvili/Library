using static Library.Common.GlobalVariables;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Services.Abstractions;
using Library.WebApp.Controllers.Abstractions;

namespace Library.WebApp.Controllers
{
    [Authorize(Roles = SuperAdminRoleName + "," + AdminRoleName)]
    public class SettingsController : BaseController
    {
        #region PRIVATE FIELDS

        #endregion

        #region CTOR

        public SettingsController(IFileLogger logger)
            : base(logger)
        {

        }

        #endregion

        public IActionResult Index()
        {
            return View();
        }
    }
}
