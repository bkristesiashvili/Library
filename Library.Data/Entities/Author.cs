using Library.Data.Entities.Abstractions;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Entities
{
    public sealed class Author : BaseEntity
    {
        public Author() => Books = new HashSet<AuthoredBooks>();

        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        public ICollection<AuthoredBooks> Books { get; set; }
    }
}
