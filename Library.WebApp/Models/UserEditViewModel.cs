using static Library.Common.GlobalVariables;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WebApp.Models
{
    public sealed class UserEditViewModel
    {
        [Required(ErrorMessage = FirstNameRequiredErrorMessage)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = LastNameRequiredErrorMessage)]
        public string LastName { get; set; }

        [Required(ErrorMessage = EmailErrorMessage)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = EmailConfirmErrorMessage)]
        [EmailAddress]
        [Compare(nameof(Email), ErrorMessage = EmailMismatchErrorMesssage)]
        public string ConfirmEmail { get; set; }

        [Required(ErrorMessage = PasswordRequiredErrorMessage)]
        public string Password { get; set; }

        [Required(ErrorMessage = PasswordConfirmErrorMessage)]
        [Compare(nameof(Password), ErrorMessage = PasswordMismatchErrorMessage)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = RoleRequiredErrorMessage)]
        public string Role { get; set; }

    }
}
