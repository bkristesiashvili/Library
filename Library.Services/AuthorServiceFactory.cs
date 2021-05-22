using Library.Common.Enums;
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
    public sealed class AuthorServiceFactory : IAuthorService
    {
        #region PRIVATE FIELDS

        private readonly IUnitOfWorks _unitOfWorks;

        #endregion

        #region CTOR

        public AuthorServiceFactory(IUnitOfWorks uow)
            => _unitOfWorks = uow;

        #endregion

        #region PUBLIC METHODS

        public Task<IQueryable<Author>> GetAllAuthorsAsync(IFilter filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<Author> GetAuthorDetailsByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task CreateNewAuthor(Author newAuthor)
        {
            throw new NotImplementedException();
        }

        public Task EditAuthorInfo(Guid id, Author updatedAuthor)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAuthorInfo(Guid id, DeletionType type = DeletionType.Hard)
        {
            throw new NotImplementedException();
        }

        public void Dispose() => GC.Collect();

        #endregion
    }
}
