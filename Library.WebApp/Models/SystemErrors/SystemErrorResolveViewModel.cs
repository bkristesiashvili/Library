using static Library.Common.GlobalVariables;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Library.WebApp.Helpers.Attributes;

namespace Library.WebApp.Models
{
    public sealed class SystemErrorResolveViewModel
    {
        #region PUBLIC PROPERTIES

        [HiddenInput]
        public Guid Id { get; set; }

        [Required(ErrorMessage = SystemErrorCommentTextRequired)]
        [InputSanitization(ErrorMessage = InvalidInputMessage)]
        public string Comment { get; set; }

        #endregion
    }
}
