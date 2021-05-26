using Library.Common.Requests.Filters.Abstractions;
using Library.Data.Entities;
using Library.Data.Repositories.Uow.Abstractions;
using Library.Services.Abstractions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services
{
    public class CustomersServiceFactory : BaseService, ICustomersService
    {
        #region CTOR

        public CustomersServiceFactory(IUnitOfWorks uow)
            : base(uow) { }

        #endregion

        #region PUBLIC METHODS

        public async Task<IQueryable<Customer>> GetAllCustomers(IFilter filter = null)
        {
            EnsureDependencies();

            return await UnitOfWorks.CustomersRepository.GetAll(filter);
        }

        public void Dispose() => GC.Collect();

        #endregion

        #region PROTECTED OVERRIDED METHODS

        protected override void EnsureDependencies()
        {
            if (UnitOfWorks == null)
                throw new ArgumentNullException($"{nameof(CustomersServiceFactory)} " +
                    $"UOW object null refference exception!");
        }

        #endregion
    }
}
