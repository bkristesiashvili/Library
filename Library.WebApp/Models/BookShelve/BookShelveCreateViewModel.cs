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
    public sealed class BookShelveCreateViewModel
    {
        #region PUBLIC PROPERTIES

        [Required(ErrorMessage = BookSHelveNameRequiredMessage)]
        [InputSanitization(ErrorMessage = InvalidInputMessage)]
        public string Name { get; set; }

        [Required(ErrorMessage = SectionNameRequiredMessage)]
        public Guid SectionId { get; set; }

        #endregion
    }
}
