using Library.Data.Entities;

using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;
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

        #endregion

        #region METHODS

        Task<IdentityResult> RegisterUserAsync(User newUser, string password,
            IEnumerable<string> roles);

        Task<User> GetAuthenticatedUser(ClaimsPrincipal principal);

        Task<IdentityResult> UpdateUserProfileAsync(User oldUser, string firstName, 
            string lastName, string email);

        Task<IdentityResult> UpdateUserpasswordAsync(User user, 
            string currentPassword, string newPassword);

        Task<SignInResult> SigninAsync(string email, string password,
            bool rememberMe, bool lockOut = false);

        Task SignOutAsync();

        bool IsSignedIn(ClaimsPrincipal userPrincipal);

        #endregion

    }
}
