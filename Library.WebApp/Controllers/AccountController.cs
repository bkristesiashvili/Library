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

        [Authorize(Roles = SuperAdminRoleName + "," + AdminRoleName)]
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
                    return Json(new JsonResponse
                    {
                        Succeed = true,
                        ReturnUrl = "/account/all",
                        Message = UserCreatedSuccessMessage
                    });
            }
            return Json(new JsonResponse
            {
                Succeed = false,
                ReturnUrl = string.Empty,
                Message = UserCreateFailedMessage
            });
        }

        public IActionResult Edit() => View();

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(UserProfileEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserService.GetAuthenticatedUser(User);

                var result = await UserService.UpdateUserProfileAsync(user, model.FirstName,
                    model.LastName, model.Email);

                if (result.Succeeded)
                    return Json(new JsonResponse
                    {
                        Succeed = true,
                        Message = UserUpdatedSuccess,
                        ReturnUrl = "/account/profile"
                    });
            }

            return Json(new JsonResponse
            {
                Succeed = false,
                Message = UserProfileUpdateFailed,
                ReturnUrl = string.Empty
            });
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPassword(PasswordEditViewModel model)
        {
            var user = await UserService.GetAuthenticatedUser(User);

            if (ModelState.IsValid)
            {
                var result = await UserService
                    .UpdateUserpasswordAsync(user, model.OldPassword, model.NewPassword);

                if (result.Succeeded)
                    return Json(new JsonResponse
                    {
                        Succeed = true,
                        ReturnUrl = "/account/profile",
                        Message = PasswordUpdatedSuccessfull
                    });
            }

            return Json(new JsonResponse
            {
                Succeed = false,
                ReturnUrl = string.Empty,
                Message = PasswordUpdateFailedErrorMessage
            });
        }

        [HttpGet]
        public async Task<IActionResult> All([FromQuery] AccountFilter filter)
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
                return Json(new JsonResponse
                {
                    Succeed = false,
                    ReturnUrl = "/account/all",
                    Message = AuthorizedUserDeleteErrorMessage
                });


            var result = await UserService.DeleteUserAsync(user);

            if (result.Succeeded)
                return Json(new JsonResponse
                {
                    Succeed = true,
                    ReturnUrl = "/account/all",
                    Message = UserDeletedSuccessfull
                });

            return Json(new JsonResponse
            {
                Succeed = false,
                ReturnUrl = string.Empty,
                Message = UserDeleteFailed
            });
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromForm] UserProfileEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var existedUser = await UserService.GetUserByIdAsync(model.Id);

                if (existedUser == null)
                    return Json(new JsonResponse
                    {
                        ReturnUrl = string.Empty,
                        Succeed = false,
                        Message = UserNotFound
                    });

                var result = await UserService.UpdateUserProfileAsync(existedUser, model.FirstName,
                    model.LastName, model.Email);



                if (!result.Succeeded)
                    return Json(new JsonResponse
                    {
                        Succeed = false,
                        Message = UserProfileUpdateFailed,
                    });

                if (model.Roles == null || !model.Roles.Any())
                    return Json(new JsonResponse
                    {
                        Succeed = false,
                        Message = UserRoleErrorMessage
                    });

                await UserService.UpdateUserRoleAsync(existedUser, model.Roles.ToArray());

                return Json(new JsonResponse
                {
                    Succeed = true,
                    ReturnUrl = "/account/all",
                    Message = UserUpdatedSuccess
                });
            }

            return Json(new JsonResponse
            {
                Succeed = false,
                ReturnUrl = string.Empty,
                Message = UserProfileUpdateFailed
            });
        }

        #endregion
    }
}
