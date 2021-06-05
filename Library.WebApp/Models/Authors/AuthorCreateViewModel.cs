using static Library.Common.GlobalVariables;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Library.WebApp.Helpers.Attributes;

namespace Library.WebApp.Models
{
    public sealed class AuthorCreateViewModel
    {
        #region PUBLIC PROPERTIES

        [Required(ErrorMessage = FirstNameRequiredErrorMessage)]
        [InputSanitization(ErrorMessage = InvalidInputMessage)]
        public string FirstName{ get; set; }

        [InputSanitization(ErrorMessage = InvalidInputMessage)]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = LastNameRequiredErrorMessage)]
        [InputSanitization(ErrorMessage = InvalidInputMessage)]
        public string LastName { get; set; }

        #endregion
    }
}
