using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WebApp.Models
{
    public sealed class SystemErrorListViewModel
    {
        #region PUBLIC PROPERTIES

        [HiddenInput]
        public Guid Id { get; set; }

        public string LogType { get; set; }

        public string LogText { get; set; }

        public string RequestMethod { get; set; }

        public string RequestPath { get; set; }

        public string LogDate { get; set; }

        public bool Resolved { get; set; }

        public string Comment { get; set; }

        #endregion
    }
}
