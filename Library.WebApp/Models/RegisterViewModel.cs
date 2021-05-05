﻿using static Library.Common.GlobalVariables;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WebApp.Models
{
    public sealed class RegisterViewModel
    {
        [Required(ErrorMessage =FirstNameRequiredErrorMessage)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = LastNameRequiredErrorMessage)]
        public string LastName { get; set; }

        [Required(ErrorMessage =EmailErrorMessage)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage =EmailConfirmErrorMessage)]
        [Compare(nameof(Email), ErrorMessage =EmailMismatchErrorMesssage)]
        [EmailAddress]
        public string ConfirmEmail { get; set; }

        [Required(ErrorMessage =PasswordRequiredErrorMessage)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage =PasswordConfirmErrorMessage)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage =PasswordMismatchErrorMessage)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = RoleRequiredErrorMessage)]
        public string Role { get; set; }

    }
}
