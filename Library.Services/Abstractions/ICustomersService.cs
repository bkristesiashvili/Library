using Library.Common.Requests.Filters.Abstractions;
using Library.Data.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Abstractions
{
    public interface ICustomersService : IService
    {
        #region METHODS

        Task<IQueryable<Customer>> GetAllCustomers(IFilter filter = null, bool selectDeleted = false);

        #endregion
    }
}
