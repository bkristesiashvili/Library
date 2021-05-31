using Library.Common;
using Library.Common.Enums;
using Library.Data.Entities;
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
using Library.Data.Extensions;
using Library.Common.Responses;
using Library.Common.Requests.Filters;
using Library.WebApp.Helpers.Attributes;

namespace Library.WebApp.Controllers
{
    [Authorize]
    [ValidUser]
    public sealed class AccountsController : BaseController
    {
        #region PRIVATE READONLY VARIABLES

        private readonly IUserService UserService;

        #endregion

        #region CTOR

        public AccountsController(
            IFileLoggerService logger,
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

        [Authorize(Roles = SuperAdminRoleName + "," + AdminRoleName)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromForm] RegisterViewModel model)
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
                    return JsonResponse(true, UserCreatedSuccessMessage, AccountIndexLink);
            }
            return JsonResponse(false, UserCreateFailedMessage);
        }

        public IActionResult Edit() => View();

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile([FromForm] UserProfileEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserService.GetAuthenticatedUser(User);

                var result = await UserService.UpdateUserProfileAsync(user, model.FirstName,
                    model.LastName, model.Email);

                if (result.Succeeded)
                    return JsonResponse(true, UserUpdatedSuccess, AccountProfileLink);
            }

            return JsonResponse(false, UserProfileUpdateFailed);
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPassword([FromForm] PasswordEditViewModel model)
        {
            var user = await UserService.GetAuthenticatedUser(User);

            if (ModelState.IsValid)
            {
                var result = await UserService
                    .UpdateUserpasswordAsync(user, model.OldPassword, model.NewPassword);

                if (result.Succeeded)
                    return JsonResponse(true, AccountProfileLink, PasswordUpdatedSuccessfull);
            }

            return JsonResponse(false, PasswordUpdateFailedErrorMessage);
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] AccountFilter filter)
        {
            Guid.TryParse(User.GetUserId(), out var currentUserId);

            var users = from user in await UserService.GetAllUsersList(filter)
                        where user.Id != currentUserId
                        select new UserListViewModel
                        {
                            Id = user.Id,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            Email = user.Email
                        };

            ViewBag.Search = filter.Search;
            ViewBag.Ordering = filter.Ordering;
            ViewBag.OrderBy = filter.OrderBy;

            return View(await users.ToPagedListAsync(filter.Page, filter.PageSize));
        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromForm] Guid id)
        {
            Guid.TryParse(User.GetUserId(), out var currentUserId);



            var user = await UserService.GetUserByIdAsync(id);

            if (id == currentUserId)
                return JsonResponse(false, AuthorizedUserDeleteErrorMessage, AccountIndexLink);


            var result = await UserService.DeleteUserAsync(user);

            if (result.Succeeded)
                return JsonResponse(true, UserDeletedSuccessfull, AccountIndexLink);

            return JsonResponse(false, UserDeleteFailed);
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromForm] UserProfileEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var existedUser = await UserService.GetUserByIdAsync(model.Id);

                if (existedUser == null)
                    return JsonResponse(false, UserNotFound);

                var result = await UserService.UpdateUserProfileAsync(existedUser, model.FirstName,
                    model.LastName, model.Email);



                if (!result.Succeeded)
                    return JsonResponse(false, UserProfileUpdateFailed);

                if (model.Roles == null || !model.Roles.Any())
                    return JsonResponse(false, UserRoleErrorMessage);

                await UserService.UpdateUserRoleAsync(existedUser, model.Roles.ToArray());

                return JsonResponse(true, UserUpdatedSuccess, AccountIndexLink);
            }

            return JsonResponse(false, UserProfileUpdateFailed);
        }

        #endregion
    }
}
