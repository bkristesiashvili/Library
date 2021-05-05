using Library.Common;
using Library.Common.Enums;
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
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;

        public AccountController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.AvailableRoles = GetAvailableRoles();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            ViewBag.AvailableRoles = GetAvailableRoles();

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
                    if(!string.IsNullOrEmpty(model.Role) || !string.IsNullOrWhiteSpace(model.Role))
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

        private IEnumerable<string> GetAvailableRoles()
        {
            var availableRoles = new HashSet<string>(GlobalVariables.DefaultRoles.Count);

            foreach (KeyValuePair<SystemDefaultRoles, string> item in GlobalVariables.DefaultRoles)
                availableRoles.Add(item.Value);

            return availableRoles;
        }
    }
}
