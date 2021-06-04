using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WebApp.Models
{
    public sealed class AuthorListViewModel
    {
        #region PUBLIC PROPERTIES

        [HiddenInput]
        public Guid Id { get; set; }
        public string FirstName { get; set; }

        public string Middlename { get; set; }

        public string LastName { get; set; }

        public bool IsDeleted { get; set; }


        #endregion
    }
}
