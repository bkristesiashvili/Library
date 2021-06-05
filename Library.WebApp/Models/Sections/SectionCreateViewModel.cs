using static Library.Common.GlobalVariables;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Library.WebApp.Helpers.Attributes;

namespace Library.WebApp.Models
{
    public sealed class SectionCreateViewModel
    {
        #region PUBLIC PROPERTEIS

        [Required(ErrorMessage = SectionNameRequiredMessage)]
        [InputSanitization(ErrorMessage = InvalidInputMessage)]
        public string Name { get; set; }

        [Required(ErrorMessage = SectorNameRequiredMessage)]
        public Guid SectorId { get; set; }

        #endregion
    }
}
