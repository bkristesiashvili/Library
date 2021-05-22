using Library.Common.Enums;
using Library.Common.Requests.Filters.Abstractions;
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

        Task<IQueryable<Author>> GetAllAuthorsAsync(IFilter filter = null);

        Task<Author> GetAuthorDetailsByIdAsync(Guid id);

        Task CreateNewAuthor(Author newAuthor);

        Task EditAuthorInfo(Guid id, Author updatedAuthor);

        Task DeleteAuthorInfo(Guid id, DeletionType type = DeletionType.Hard);

        #endregion
    }
}
