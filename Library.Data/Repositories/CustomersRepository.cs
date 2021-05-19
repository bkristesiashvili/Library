using Library.Common.Requests.Filters.Abstractions;
using Library.Data.Entities;
using Library.Data.Repositories.Abstractions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Repositories
{
    public sealed class CustomersRepository : BaseRepository<Customer>
    {
        #region CTOR

        public CustomersRepository(LibraryDbContext context)
            : base(context) { }

        #endregion

        #region OVERRIDED METHODS

        public override async Task<IQueryable<Customer>> GetAll(IFilter filter = null)
        {
            var customers = await base.GetAll(filter);

            return CheckSearchFilter(filter)
                ? from customer in customers
                  where customer.FirstName.StartsWith(filter.Search) ||
                        customer.MiddleName.StartsWith(filter.Search) ||
                        customer.LastName.StartsWith(filter.Search) ||
                        customer.IdentityNumber.StartsWith(filter.Search) ||
                        customer.Phone.StartsWith(filter.Search)
                  select customer
                : customers;
        }

        #endregion
    }
}
