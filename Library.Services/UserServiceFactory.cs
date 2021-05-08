using Library.Data.Entities;
using Library.Services.Abstractions;

using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services
{
    public sealed class UserServiceFactory : IUserService
    {
        #region PRIVATE VARIABLES

        private bool _disposed = false;

        #endregion

        #region PUBLIC PROPERTIES

        public UserManager<User> UserManager { get; }

        public SignInManager<User> SigninManager { get; }

        #endregion

        #region CTOR

        public UserServiceFactory(UserManager<User> userManager,
            SignInManager<User> signinManager)
        {
            UserManager = userManager;
            SigninManager = signinManager;

            EnsureDependencies();
        }

        #endregion

        #region PUBLIC METHODS

        public async Task<IdentityResult> RegisterUserAsync(User newUser, string password,
            params string[] roles)
        {
            var result = new IdentityResult();

            if (newUser == null)
                return result;

            if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
                return result;

            if (!roles.Any())
                return result;

            result = await UserManager.CreateAsync(newUser, password);

            if (result.Succeeded)
                result = await UserManager.AddToRolesAsync(newUser, roles);
            
            return result;
        }

        public async Task<User> GetAuthenticatedUser(ClaimsPrincipal principal)
            => await UserManager.GetUserAsync(principal);

        public async Task<IdentityResult> UpdateUserProfileAsync(User user, string firstName,
            string lastName, string email)
        {
            var result = new IdentityResult();

            if (user == null)
                return result;

            user.FirstName = firstName;
            user.LastName = lastName;
            user.Email = email;
            user.UserName = email;

            result = await UserManager.UpdateAsync(user);

            return result;
        }

        public async Task<IdentityResult> UpdateUserpasswordAsync(User user, 
            string currentPassword, string newPassword)
        {
            var result = new IdentityResult();

            if (user == null)
                return result;

            if (string.IsNullOrEmpty(currentPassword) || string.IsNullOrWhiteSpace(currentPassword))
                return result;

            if (string.IsNullOrEmpty(newPassword) || string.IsNullOrWhiteSpace(newPassword))
                return result;

            result = await UserManager.ChangePasswordAsync(user, currentPassword, newPassword);

            return result;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        #endregion

        #region PRIVATE METHODS

        private void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                UserManager.Dispose();
                GC.Collect();
            }
        }

        private void EnsureDependencies()
        {
            if (UserManager == null)
                throw new ArgumentNullException(nameof(UserManager));
            if (SigninManager == null)
                throw new ArgumentNullException(nameof(SigninManager));
        }

        #endregion
    }
}
