using static Library.Common.GlobalVariables;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WebApp.Models
{
    public sealed class BookShelveCreateViewModel
    {
        #region PUBLIC PROPERTIES

        [Required(ErrorMessage = BookSHelveNameRequiredMessage)]
        public string Name { get; set; }

        [Required(ErrorMessage = SectionNameRequiredMessage)]
        public Guid SectionId { get; set; }

        #endregion
    }
}
