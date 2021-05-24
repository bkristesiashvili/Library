using static Library.Common.GlobalVariables;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WebApp.Models
{
    public sealed class AuthorCreateViewModel
    {
        #region PUBLIC PROPERTIES

        [Required(ErrorMessage = FirstNameRequiredErrorMessage)]
        public string FirstName{ get; set; }

        public string MiddleName { get; set; }

        [Required(ErrorMessage = LastNameRequiredErrorMessage)]
        public string LastName { get; set; }

        #endregion
    }
}
