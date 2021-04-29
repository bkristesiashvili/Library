using Library.Data.Entities.Abstractions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Entities
{
    public class BorrowedBook : BaseEntity
    {
        public Guid BookId { get; set; }
        public Book Book { get; set; }

        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime ExiperDate { get; set; }

        public BorrowStatus Status { get; set; }
    }
}
