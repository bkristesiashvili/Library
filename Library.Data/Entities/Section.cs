
using Library.Data.Entities.Abstractions;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Entities
{
    public sealed class Section : BaseEntity
    {
        public Section() => BookShelves = new HashSet<BookShelve>();

        [Required]
        public string Name { get; set; }

        public Guid SectorId { get; set; }
        public Sector Sector { get; set; }

        public ICollection<BookShelve> BookShelves { get; set; }

    }
}
