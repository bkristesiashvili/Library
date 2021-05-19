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
    public class CustomersServiceFactory : ICustomersService
    {
        #region PRIVATE FIELDS

        private readonly IUnitOfWorks _unitOfWorks;

        #endregion

        #region CTOR

        public CustomersServiceFactory(IUnitOfWorks uow)
            => _unitOfWorks = uow;

        #endregion

        #region PUBLIC METHODS

        public async Task<IQueryable<Customer>> GetAllCustomers(IFilter filter = null)
        {
            EnsureDependencies();

            return await _unitOfWorks.CustomersRepository.GetAll(filter);
        }

        #endregion

        #region PRIVATE METHODS

        private void EnsureDependencies()
        {
            if (_unitOfWorks == null)
                throw new ArgumentNullException("Unit of works object null refference exception!");
        }

        #endregion
    }
}
