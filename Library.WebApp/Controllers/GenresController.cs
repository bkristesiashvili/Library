using static Library.Common.GlobalVariables;

using Library.Common.Requests.Filters;
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
using Library.WebApp.Helpers.Extensions;

namespace Library.WebApp.Controllers
{
    [Authorize]
    public class GenresController : BaseController
    {
        #region PRIVATE FIELDS

        private readonly IGenreService genreService;

        #endregion

        #region CTOR

        public GenresController(IFileLoggerService logger,
            IGenreService genreService)
            : base(logger)
        {
            this.genreService = genreService;
        }

        #endregion

        #region ACTIONS

        [HttpGet]
        public async Task<IActionResult> IndexAsync([FromQuery] GenreFilter filter)
        {
            var genreList = from genre in await genreService.GetAllGenresAsync(filter)
                            select new GenreListViewModel
                            {
                                Id = genre.Id,
                                Name = genre.Name,
                                CreateDate = genre.CreatedAt.ToDateString()
                            };

            ViewBag.Search = filter.Search;
            ViewBag.Ordering = filter.Ordering;
            ViewBag.OrderBy = filter.OrderBy;

            return View(await genreList.ToPagedListAsync(filter.Page, filter.PageSize));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAsync([FromForm]GenreCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await genreService.CreateGenreAsync(new Genre
                {
                    Name = model.Name
                });

                if (result.Succeed)
                    return JsonResponse(true, GenreCreatedSuccessMessage, GenreIndexLink);
            }
            return JsonResponse(false, GenreCreateFailedMessage);
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync([FromForm] GenreEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await genreService.EditGenreAsync(model.Id, new Genre
                {
                    Name = model.Name
                });

                if (result.Succeed)
                    return JsonResponse(true, GenreEditSuccessMessage, GenreIndexLink);
            }
            return JsonResponse(false, GenreEditFailedMessage);
        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAsync([FromForm] Guid id)
        {
            var result = await genreService.DeleteGenreAsync(id);

            if (result.Succeed)
                return JsonResponse(true, GenreRecordDeleteSuccess, GenreIndexLink);
            return JsonResponse(false, GenreRecordDeleteFailed);
        }

        #endregion
    }
}
