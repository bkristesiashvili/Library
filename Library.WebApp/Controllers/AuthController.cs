using Library.Data.Entities;
using Library.WebApp.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WebApp.Controllers
{
    [Authorize]
    public class AuthController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signinManager;

        public AuthController(UserManager<User> userManager, SignInManager<User> signinManager)
        {
            this.userManager = userManager;
            this.signinManager = signinManager;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            if (signinManager.IsSignedIn(User))
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
                var result = await signinManager
                    .PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    var usr = User;
                    return RedirectToAction("index", "home");
                }

                ModelState.AddModelError(string.Empty, "არასწორი მომხმარებელი ან პაროლი!");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await signinManager.SignOutAsync();
            return RedirectToAction("login", "auth");
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult AccessDenied() => View();
    }
}
