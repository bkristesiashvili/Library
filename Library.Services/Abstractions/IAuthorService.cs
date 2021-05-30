using Library.Common.Enums;
using Library.Common.Requests.Filters.Abstractions;
using Library.Common.Responses;
using Library.Data.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Abstractions
{
    public interface IAuthorService : IService
    {
        #region METHODS

        Task<IQueryable<Author>> GetAllAuthorsAsync(IFilter filter = null, bool selectDeleted = false);

        Task<Author> GetAuthorDetailsByIdAsync(Guid id);

        Task<ServiceResult> CreateNewAuthorAsync(Author newAuthor);

        Task<ServiceResult> EditAuthorInfoAsync(Guid id, Author updatedAuthor);

        Task<ServiceResult> DeleteAuthorInfoAsync(Guid id, DeletionType type = DeletionType.Soft);

        #endregion
    }
}
