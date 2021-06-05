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
    public sealed class SectorEditViewModel
    {
        #region PUBLIC PROPERTIES

        [HiddenInput]
        public Guid Id { get; set; }

        [Required(ErrorMessage = SectorNameRequiredMessage)]
        [InputSanitization(ErrorMessage = InvalidInputMessage)]
        public string Name { get; set; }

        [HiddenInput]
        public bool IsDeleted { get; set; }

        #endregion
    }
}
