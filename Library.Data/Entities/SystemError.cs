using Library.Data.Entities.Abstractions;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.Data.Entities
{
    public sealed class SystemError : BaseEntity
    {
        #region PUBLIC PROPERTIES

        [Required]
        public string LogType { get; set; }

        [Required]
        public string LogText { get; set; }

        [Required]
        public string RequestMethod { get; set; }

        [Required]
        public string RequestPath { get; set; }

        [Required]
        public DateTime LogDate { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool Resolved { get; set; }

        #endregion
    }
}
