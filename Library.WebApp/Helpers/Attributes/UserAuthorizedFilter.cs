using static Library.Common.GlobalVariables;

using Library.Services.Abstractions;
using Library.WebApp.Helpers.Extensions;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WebApp.Helpers.Attributes
{
    public sealed class UserAuthorizedFilter : IAuthorizationFilter
    {
        #region PRIVATE FIELDS

        private readonly IUserService userService;

        #endregion

        #region CTOR

        public UserAuthorizedFilter(IUserService userService)
            => this.userService = userService;

        #endregion

        #region PUBLIC METHODS

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var userClaims = context.HttpContext.User;

            if(!userClaims.Identity.IsAuthenticated)
            {
                RedirectToLogin(context.HttpContext);
                return;
            }

            var idStr = userClaims.GetUserId();

            if(!Guid.TryParse(idStr, out var id))
            {
                RedirectToLogin(context.HttpContext);
                return;
            }

            var userById = userService.GetUserByIdAsync(id)
                .Result;

            if(userById == null)
            {
                RedirectToLogin(context.HttpContext);
                return;
            }
        }

        #endregion

        #region PRIVATE METHODS

        private void DeleteCookies(HttpContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(HttpContext));

            var ownKeys = context.Request.Cookies.Keys
                .Where(key => key.Equals(AntiForgeryCoockieName) ||
                              key.Equals(LibraryWebCookieName))
                .ToList();

            ownKeys.ForEach(key =>
            {
                context.Response.Cookies.Delete(key);
            });
        }

        private void RedirectToLogin(HttpContext context)
        {
            DeleteCookies(context);
            context.Response.Redirect(LoginLink);
        }

        #endregion
    }
}
