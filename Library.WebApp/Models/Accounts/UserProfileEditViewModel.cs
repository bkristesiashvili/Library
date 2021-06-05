using static Library.Common.GlobalVariables;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Library.Common;
using Library.Common.Enums;
using Microsoft.AspNetCore.Mvc;
using Library.WebApp.Helpers.Attributes;

namespace Library.WebApp.Models
{
    public sealed class UserProfileEditViewModel
    {
        #region PUBLIC PROPERTIES

        [HiddenInput]
        public Guid Id { get; set; }

        [Required(ErrorMessage = FirstNameRequiredErrorMessage)]
        [InputSanitization(ErrorMessage = InvalidInputMessage)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = LastNameRequiredErrorMessage)]
        [InputSanitization(ErrorMessage = InvalidInputMessage)]
        public string LastName { get; set; }

        [Required(ErrorMessage = EmailErrorMessage)]
        [EmailAddress(ErrorMessage = EmailFormatError)]
        public string Email { get; set; }

        public IEnumerable<string> Roles { get; set; }

        #endregion
    }
}
