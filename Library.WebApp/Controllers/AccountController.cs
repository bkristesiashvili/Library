using Library.Common;
using Library.Common.Enums;
using Library.Data.Entities;
using Library.Data.Request.Filters;
using Library.Services.Abstractions;
using Library.WebApp.Controllers.Abstractions;
using Library.WebApp.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WebApp.Controllers
{
    [Authorize]
    public sealed class AccountController : BaseController
    {
        #region PRIVATE READONLY VARIABLES

        private readonly IUserService UserService;

        #endregion

        #region CTOR

        public AccountController(
            IFileLogger logger,
            IUserService userService
            )
            :base(logger)
        {
            UserService = userService;
        }

        #endregion

        #region ACTIONS

        [HttpGet]
        public IActionResult Profile() => View();

        [HttpGet]
        public IActionResult Register() => View(new RegisterViewModel());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {

                var result = await UserService.RegisterUserAsync(new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    UserName = model.Email
                },model.Password, model.Roles);

                if (result.Succeeded)
                    ViewBag.Success = "მომხმარებელი წარმატებით შეიქმნა.";
                else
                    ViewBag.Error = "ასეთი მომხმარებელი უკვე არსებობს!";

            }
            return View(model);
        }

        public IActionResult Edit() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(UserProfileEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserService.GetAuthenticatedUser(User);

                var result = await UserService.UpdateUserProfileAsync(user, model.FirstName,
                    model.LastName, model.Email);

                if (result.Succeeded)
                    ViewBag.Success = "პროფილი წარმატებით განახლდა.";
                else
                    ViewBag.Error = "პროფილის განახლება ვერ მოხერხდა!";
            }

            return View("edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPassword(PasswordEditViewModel model)
        {
            var user = await UserService.GetAuthenticatedUser(User);

            if (ModelState.IsValid)
            {
                var result = await UserService
                    .UpdateUserpasswordAsync(user, model.OldPassword, model.NewPassword);

                if (result.Succeeded)
                    ViewBag.Success = "პაროლი წარმატებით განახლდა.";
                else
                    ViewBag.Error = "პაროლის განახლება ვერ მოხერხდა!";
            }

            return View("edit");
        }

        public async Task<IActionResult> getAllUsers([FromQuery] AccountFilter filter)
        {
            var users = await UserService.GetAllUsersList(filter);

            var conv = users.ToList();

            return Json(conv);
        }

        #endregion
    }
}
