using static Library.Common.GlobalVariables;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Library.Common;
using Library.Common.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebApp.Models
{
    public sealed class UserProfileEditViewModel
    {
        [HiddenInput]
        public Guid Id { get; set; }

        [Required(ErrorMessage = FirstNameRequiredErrorMessage)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = LastNameRequiredErrorMessage)]
        public string LastName { get; set; }

        [Required(ErrorMessage = EmailErrorMessage)]
        [EmailAddress]
        public string Email { get; set; }

        public IEnumerable<string> Roles { get; set; }
    }
}
