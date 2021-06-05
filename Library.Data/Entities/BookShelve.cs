using Library.Data.Entities.Abstractions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Entities
{
    public sealed class BookShelve : BaseEntity
    {
        public BookShelve() => Books = new HashSet<BooksBookshelve>();

        public string Name { get; set; }

        public Guid SectionId { get; set; }
        public Section Section { get; set; }

        public ICollection<BooksBookshelve> Books { get; set; }

    }
}
