using static Library.Common.GlobalVariables;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Library.WebApp.Helpers.Attributes;

namespace Library.WebApp.Models
{
    public sealed class GenreCreateViewModel
    {
        #region PROPERTIES

        [Required(ErrorMessage = GenreNameReuiredMessage)]
        [InputSanitization(ErrorMessage = InvalidInputMessage)]
        public string Name { get; set; }

        #endregion
    }
}
