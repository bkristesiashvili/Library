﻿
using Library.Data.Entities.Abstractions;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Entities
{
    public sealed class Genre : BaseEntity
    {
        public Genre() => Books = new HashSet<BookGenres>();

        [Required]
        public string Name { get; set; }

        public ICollection<BookGenres> Books { get; set; }
    }
}
