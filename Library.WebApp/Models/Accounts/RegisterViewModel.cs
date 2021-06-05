using static Library.Common.GlobalVariables;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Library.Common.Enums;
using Library.WebApp.Helpers.Attributes;

namespace Library.WebApp.Models
{
    public sealed class RegisterViewModel
    {
        #region PUBLIC PROPERTIES

        [Required(ErrorMessage =FirstNameRequiredErrorMessage)]
        [InputSanitization(ErrorMessage = InvalidInputMessage)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = LastNameRequiredErrorMessage)]
        [InputSanitization(ErrorMessage = InvalidInputMessage)]
        public string LastName { get; set; }

        [Required(ErrorMessage =EmailErrorMessage)]
        [EmailAddress(ErrorMessage = EmailFormatError)]
        public string Email { get; set; }

        [Required(ErrorMessage =EmailConfirmErrorMessage)]
        [Compare(nameof(Email), ErrorMessage =EmailMismatchErrorMesssage)]
        [EmailAddress(ErrorMessage = EmailFormatError)]
        public string ConfirmEmail { get; set; }

        [Required(ErrorMessage =PasswordRequiredErrorMessage)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage =PasswordConfirmErrorMessage)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage =PasswordMismatchErrorMessage)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = RoleRequiredErrorMessage)]
        public IEnumerable<string> Roles { get; set; }

        #endregion
    }
}
