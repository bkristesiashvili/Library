using Library.Common;
using Library.Common.Enums;
using Library.Data.Entities;
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
    public class AccountController : BaseController
    {
        private readonly UserManager<User> userManager;

        public AccountController(
            IFileLogger logger,
            UserManager<User> userManager
            )
            :base(logger)
        {
            this.userManager = userManager;
        }

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
                var newUser = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    UserName = model.Email,
                };

                var result = await userManager.CreateAsync(newUser, model.Password);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.Role) || !string.IsNullOrWhiteSpace(model.Role))
                    {
                        await userManager.AddToRoleAsync(newUser, model.Role);
                        ViewBag.Success = "მომხმარებელი წარმატებით შეიქმნა.";
                    }
                }
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
                var user = await userManager.GetUserAsync(User);

                user.Email = model.Email;
                user.UserName = model.Email;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;

                var result = await userManager.UpdateAsync(user);

                if (result.Succeeded)
                    return RedirectToAction(nameof(Profile));

                ModelState.AddModelError(string.Empty, "განახლების დროს დაფიქსირდა შეცდომა!");
            }

            return View("edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPassword(PasswordEditViewModel model)
        {
            var user = await userManager.GetUserAsync(User);
            if (ModelState.IsValid)
            {
                var passwordHasher = userManager.PasswordHasher;

                var verified = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, model.OldPassword);

                
            }
            return View("edit", new UserProfileEditViewModel
            {
                Email = user?.Email,
                FirstName = user?.FirstName,
                LastName = user?.LastName
            });
        }
    }
}
