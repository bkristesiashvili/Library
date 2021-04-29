
using Library.Data.Entities.Abstractions;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Entities
{
    public sealed class Sector : BaseEntity
    {
        public Sector() => Sections = new HashSet<Section>();

        [Required]
        public string Name { get; set; }

        public ICollection<Section> Sections { get; set; }
    }
}
