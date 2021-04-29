
using Library.Data.Entities.Abstractions;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Entities
{
    public sealed class Book : BaseEntity
    {
        public Book()
        {
            Genres = new HashSet<BookGenres>();
            Authors = new HashSet<AuthoredBooks>();
            BookShelves = new HashSet<BooksBookshelve>();
            Customers = new HashSet<BorrowedBook>();
        }

        [Required]
        public string Title { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        public int Count { get; set; }

        public ICollection<BookGenres> Genres { get; set; }

        public ICollection<AuthoredBooks> Authors { get; set; }

        public ICollection<BooksBookshelve> BookShelves { get; set; }

        public ICollection<BorrowedBook> Customers { get; set; }
    }
}
