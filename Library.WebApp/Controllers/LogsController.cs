using static Library.Common.GlobalVariables;

using Library.Common.Requests.Filters;
using Library.Data.Extensions;
using Library.Services.Abstractions;
using Library.WebApp.Controllers.Abstractions;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.WebApp.Models;
using Library.Common.Extensions;

namespace Library.WebApp.Controllers
{
    public class LogsController : BaseController
    {
        #region CTOR

        public LogsController(IFileLoggerService logger)
            : base(logger) { }

        #endregion

        #region ACTIONS

        [HttpGet]
        public async Task<IActionResult> IndexAsync([FromQuery] SystemErrorFilter filter)
        {
            var errors = from error in await Logger.GetAllSystemErrorsAsync(filter, filter.Checked)
                         select new SystemErrorListViewModel
                         {
                             Id = error.Id,
                             LogType = error.LogType,
                             LogText = error.LogText,
                             LogDate = error.LogDate.ToDateString(),
                             RequestMethod = error.RequestMethod,
                             RequestPath = error.RequestPath,
                             Resolved = error.Resolved
                         };

            ViewBag.Search = filter.Search;
            ViewBag.Ordering = filter.Ordering;
            ViewBag.OrderBy = filter.OrderBy;
            ViewBag.SelectDeleted = filter.Checked;
            ViewBag.PageSize = filter.PageSize;
            ViewBag.From = filter.From;
            ViewBag.To = filter.To;

            return View(await errors.ToPagedListAsync(filter.Page, LogsIndexLink, filter.PageSize));
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResolveAsync([FromForm] SystemErrorResolveViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await Logger.ResolveSystemErrorAsync(model.Id, model.Comment);

                if (result.Succeed)
                    return JsonResponse(true, SystemErrorResolvedSuccessMessage, LogsIndexLink);
            }

            return JsonResponse(false, SystemErrorResolvedFailedMessage);
        }

        #endregion
    }
}
