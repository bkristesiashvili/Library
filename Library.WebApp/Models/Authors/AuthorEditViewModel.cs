using static Library.Common.GlobalVariables;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Library.WebApp.Helpers.Attributes;

namespace Library.WebApp.Models
{
    public class AuthorEditViewModel
    {
        #region PUBLIC PROPERTIES

        [HiddenInput]
        public Guid Id { get; set; }

        [Required(ErrorMessage = FirstNameRequiredErrorMessage)]
        [InputSanitization(ErrorMessage = InvalidInputMessage)]
        public string FirstName { get; set; }

        [InputSanitization(ErrorMessage = InvalidInputMessage)]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = LastNameRequiredErrorMessage)]
        [InputSanitization(ErrorMessage = InvalidInputMessage)]
        public string LastName { get; set; }

        #endregion
    }
}
