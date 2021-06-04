using static Library.Common.GlobalVariables;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebApp.Models
{
    public sealed class GenreEditViewModel
    {
        #region pPUBLIC PROPERTIES

        [HiddenInput]
        public Guid Id { get; set; }

        [Required(ErrorMessage = GenreNameReuiredMessage)]
        public string Name { get; set; }

        #endregion
    }
}
