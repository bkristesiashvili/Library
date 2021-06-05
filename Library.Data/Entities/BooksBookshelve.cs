using Library.Data.Entities.Abstractions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Entities
{
    public sealed class BooksBookshelve : BaseEntity
    {
        public Guid BookshelveId { get; set; }
        public BookShelve BookShelve { get; set; }

        public Guid BookId { get; set; }
        public Book Book { get; set; }
    }
}
