using Library.Data;
using Library.Data.Entities;
using Library.Data.Request.Filters.Abstractions;

using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Abstractions
{
    public interface IUserService : IDisposable
    {
        #region PROPERTIES

        UserManager<User> UserManager { get; }

        SignInManager<User> SigninManager { get; }

        RoleManager<Role> RoleManager { get; }

        LibraryDbContext DbContext { get; }

        #endregion

        #region METHODS

        Task<IdentityResult> RegisterUserAsync(User newUser, string password,
            IEnumerable<string> roles);

        Task<User> GetAuthenticatedUser(ClaimsPrincipal principal);

        Task<IdentityResult> UpdateUserProfileAsync(User user, string firstName, 
            string lastName, string email);

        Task<IdentityResult> UpdateUserRoleAsync(User user, params string[] roles);

        Task<IdentityResult> UpdateUserpasswordAsync(User user, 
            string currentPassword, string newPassword);

        Task<SignInResult> SigninAsync(string email, string password,
            bool rememberMe, bool lockOut = false);

        Task SignOutAsync();

        bool IsSignedIn(ClaimsPrincipal userPrincipal);

        Task<IQueryable<User>> GetAllUsersList(IFilter filert = null);

        Task<User> GetUserByIdAsync(Guid id);

        Task<IdentityResult> DeleteUserAsync(User user);

        Task<IEnumerable<Role>> GetAvailableRolesAsync();

        Task<IEnumerable<string>> GetUserRolesAsync(User user);

        bool UserIsInRole(User user, string role);

        #endregion

    }
}
