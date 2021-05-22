
using static Library.Common.GlobalVariables;
using Library.Data.Entities;
using Library.Services.Abstractions;
using Library.WebApp.Controllers.Abstractions;
using Library.WebApp.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Common.Responses;

namespace Library.WebApp.Controllers
{
    [Authorize]
    public class AuthController : BaseController
    {
        #region PRIVATE VARIABLES

        private readonly IUserService userService;

        #endregion

        #region CTOR

        public AuthController(IFileLoggerService logger, IUserService userService)
            : base(logger)
        {
            this.userService = userService;
        }

        #endregion

        #region ACTIONS

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            if (userService.IsSignedIn(User))
                return RedirectToAction("index", "home");
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await userService
                    .SigninAsync(model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                    return Json(new JsonResponse
                    {
                        Succeed = true,
                        ReturnUrl = model.ReturnUrl ?? DefaultUrl,
                        Message = AuthorizationSuccess
                    });
            }

            return Json(new JsonResponse
            {
                Succeed = false,
                Message = AuthorizationFailed
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await userService.SignOutAsync();
            return Json(new JsonResponse
            {
                Succeed = true,
                Message = UserSignedOutSuccess,
                ReturnUrl = "/auth/login"
            });
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult AccessDenied() => View();

        #endregion
    }
}
