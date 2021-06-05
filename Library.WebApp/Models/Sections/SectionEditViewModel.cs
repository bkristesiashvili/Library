using static Library.Common.GlobalVariables;

using Library.WebApp.Helpers.Attributes;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WebApp.Models
{
    public sealed class SectionEditViewModel
    {
        #region PUBLIC PROPERTIES

        [HiddenInput]
        public Guid Id { get; set; }

        [InputSanitization(ErrorMessage = InvalidInputMessage)]
        public string Name { get; set; }

        [HiddenInput]
        public bool IsDeleted { get; set; }

        public Guid SectorId { get; set; }

        #endregion
    }
}
