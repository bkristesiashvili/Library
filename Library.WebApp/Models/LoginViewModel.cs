using static Library.Common.GlobalVariables;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WebApp.Models
{
    public sealed class LoginViewModel
    {
        [Required(ErrorMessage = EmailErrorMessage)]
        [EmailAddress(ErrorMessage = EmailFormatError)]
        [Display(Name = EmailDisplayName)]
        public string Email { get; set; }

        [Required(ErrorMessage = PasswordRequiredErrorMessage)]
        [Display(Name = PasswordDisplayName)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Description = RememberMeDisplayName, Name = RememberMeDisplayName)]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
