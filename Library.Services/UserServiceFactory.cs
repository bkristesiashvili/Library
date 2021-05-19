using Library.Common.Requests.Filters.Abstractions;
using Library.Data;
using Library.Data.Entities;
using Library.Data.Extensions;
using Library.Services.Abstractions;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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
        private readonly RoleManager<Role> roleManager;

        #endregion

        #region PUBLIC PROPERTIES

        public UserManager<User> UserManager { get; }

        public SignInManager<User> SigninManager { get; }

        public RoleManager<Role> RoleManager { get; }

        public LibraryDbContext DbContext { get; }

        #endregion

        #region CTOR

        public UserServiceFactory(UserManager<User> userManager,
            SignInManager<User> signinManager,
            RoleManager<Role> roleManager,
            LibraryDbContext context)
        {
            UserManager = userManager;
            SigninManager = signinManager;
            RoleManager = roleManager;
            DbContext = context;

            EnsureDependencies();
        }

        #endregion

        #region PUBLIC METHODS

        public async Task<IdentityResult> RegisterUserAsync(User newUser, string password,
            IEnumerable<string> roles)
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

        public async Task<IdentityResult> UpdateUserRoleAsync(User user, params string[] roles)
        {
            var userRoles = await GetUserRolesAsync(user);

            var diffExitedRoles = userRoles.Except(roles).ToList();
            var diffNewRoles = roles.Except(userRoles).ToList();

            await UserManager.RemoveFromRolesAsync(user, diffExitedRoles);

            return await UserManager.AddToRolesAsync(user, diffNewRoles);
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

        public async Task<SignInResult> SigninAsync(string email, string password, bool rememberMe, bool lockOut = false)
            => await SigninManager.PasswordSignInAsync(email, password, rememberMe, lockOut);

        public async Task SignOutAsync()
            => await SigninManager.SignOutAsync();

        public bool IsSignedIn(ClaimsPrincipal userPrincipal)
            => SigninManager.IsSignedIn(userPrincipal);

        public async Task<IQueryable<User>> GetAllUsersList(IFilter filter = null)
        {
            var results = filter == null
                ? await Task.FromResult(DbContext.Users)
                : await Task.FromResult(DbContext.Users.OrderBy(filter));

            return string.IsNullOrEmpty(filter.Search) || string.IsNullOrWhiteSpace(filter.Search)
                ? results
                : from entity in results
                  where entity.FirstName.StartsWith(filter.Search) ||
                        entity.LastName.StartsWith(filter.Search) ||
                        entity.Email.StartsWith(filter.Search)
                  select entity;
        }

        public async Task<IdentityResult> DeleteUserAsync(User user)
            => await UserManager.DeleteAsync(user);

        public async Task<User> GetUserByIdAsync(Guid id)
            => await UserManager.FindByIdAsync(id.ToString());

        public async Task<IEnumerable<Role>> GetAvailableRolesAsync()
            => await DbContext.Roles.ToListAsync();

        public async Task<IEnumerable<string>> GetUserRolesAsync(User user)
            => await UserManager.GetRolesAsync(user);

        public bool UserIsInRole(User user, string role)
            => UserManager.IsInRoleAsync(user, role).Result;

        public void Dispose()
            => Dispose(true);

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
            if (RoleManager == null)
                throw new ArgumentNullException(nameof(RoleManager));
            if (DbContext == null)
                throw new ArgumentNullException(nameof(DbContext));
        }

        #endregion
    }
}
