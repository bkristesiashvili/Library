using Library.Common;
using Library.Common.Enums;
using Library.Data.Entities;
using Library.Data.Request.Filters;
using Library.Services.Abstractions;
using Library.WebApp.Controllers.Abstractions;
using Library.WebApp.Models;
using static Library.Common.GlobalVariables;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.WebApp.Helpers.Extensions;

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
            : base(logger)
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
                }, model.Password, model.Roles);

                if (result.Succeeded)
                    ViewBag.Success = "მომხმარებელი წარმატებით დაემატა.";
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

        [HttpGet]
        public async Task<IActionResult> All([FromQuery] AccountFilter filter)
        {

            var users = from user in await UserService.GetAllUsersList(filter)
                        select new UserListViewModel
                        {
                            Id = user.Id,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            Email = user.Email
                        };

            return View(users.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] Guid id)
        {
            Guid.TryParse(User.GetUserId(), out var currentUserId);

            var user = await UserService.GetUserById(id);

            if (id == currentUserId)
                return Json(new { Success = false, Location = "/account/all" });


            var result = await UserService.DeleteUserAsync(user);

            if (result.Succeeded)
                return Json(new { Success = true, Location = "/account/all" });

            return Json(new { Success = false, Location = string.Empty });
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm]UserProfileEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var existedUser = await UserService.GetUserById(model.Id);

                if (existedUser == null)
                    return Json(new
                    {
                        Success = false,
                        Location = string.Empty,
                        Message = UserNotFound
                    });

                var result = await UserService.UpdateUserProfileAsync(existedUser, model.FirstName,
                    model.LastName, model.Email);

                if (!result.Succeeded)
                    return Json(new
                    {
                        Success = false,
                        Location = string.Empty,
                        Message = UserProfileUpdateFailed
                    });

                return Json(new
                {
                    Success = true,
                    Location = "/account/all",
                    Message = UserUpdatedSuccess
                });
            }
            return Json(new
            {
                Success = false,
                Location = string.Empty,
                Message = UserProfileUpdateFailed
            });
        }

        #endregion
    }
}
