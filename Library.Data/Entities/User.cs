using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.Data.Entities
{
    public sealed class User : IdentityUser<Guid>
    {
        [Required]
        [PersonalData]
        public string FirstName { get; set; }

        [PersonalData]
        public string MiddleName { get; set; }

        [Required]
        [PersonalData]
        public string LastName { get; set; }
    }
}
