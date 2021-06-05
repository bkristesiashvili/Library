using static Library.Common.GlobalVariables;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WebApp.Models
{
    public sealed class PasswordEditViewModel
    {
        #region PUBLIC PROPERTIES

        [Required(ErrorMessage =PasswordRequiredErrorMessage)]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = PasswordRequiredErrorMessage)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = PasswordConfirmErrorMessage)]
        [DataType(DataType.Password)]
        [Compare(nameof(NewPassword), ErrorMessage = PasswordMismatchErrorMessage)]
        public string ConfirmNewPassword { get; set; }

        #endregion
    }
}
