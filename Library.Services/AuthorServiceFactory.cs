using static Library.Common.GlobalVariables;

using Library.Common.Enums;
using Library.Common.Requests.Filters.Abstractions;
using Library.Common.Responses;
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
    public sealed class AuthorServiceFactory : BaseService, IAuthorService
    {
        #region PRIVATE FIELDS

        private readonly IUnitOfWorks _unitOfWorks;

        #endregion

        #region CTOR

        public AuthorServiceFactory(IUnitOfWorks uow)
            => _unitOfWorks = uow;

        #endregion

        #region PUBLIC METHODS

        public async Task<IQueryable<Author>> GetAllAuthorsAsync(IFilter filter = null)
        {
            EnsureDependencies();

            return await _unitOfWorks.AuthorsRepository.GetAll(filter);
        }

        public async Task<Author> GetAuthorDetailsByIdAsync(Guid id)
        {
            EnsureDependencies();

            return await _unitOfWorks.AuthorsRepository.GetById(id);
        }

        public async Task<ServiceResult> CreateNewAuthorAsync(Author newAuthor)
        {
            try
            {
                EnsureDependencies();

                await _unitOfWorks.AuthorsRepository.Create(newAuthor);
                _unitOfWorks.SaveChanges();

                return new ServiceResult
                {
                    Succeed = true
                };
            }
            catch(Exception e)
            {
                return new ServiceResult
                {
                    Succeed = false,
                    Error = e
                };
            }
        }

        public async Task<ServiceResult> EditAuthorInfoAsync(Guid id, Author updatedAuthor)
        {
            try
            {


                var existed = await GetAuthorDetailsByIdAsync(id);

                if (existed == null) return new ServiceResult
                {
                    Succeed = false,
                    Error = new Exception(RecordNotFound)
                };

                existed.FirstName = updatedAuthor.FirstName;
                existed.MiddleName = updatedAuthor.MiddleName;
                existed.LastName = updatedAuthor.LastName;
                existed.UpdatedAt = DateTime.UtcNow;

                await _unitOfWorks.AuthorsRepository.Update(existed);
                _unitOfWorks.SaveChanges();

                return new ServiceResult
                {
                    Succeed = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResult
                {
                    Succeed = false,
                    Error = e
                };
            }
        }

        public async Task<ServiceResult> DeleteAuthorInfoAsync(Guid id, DeletionType type = DeletionType.Hard)
        {
            try
            {
                EnsureDependencies();

                var existed = await GetAuthorDetailsByIdAsync(id);

                if (existed == null) return new ServiceResult
                {
                    Succeed = false,
                    Error = new Exception(RecordNotFound)
                };

                await _unitOfWorks.AuthorsRepository.Delete(existed, type);
                _unitOfWorks.SaveChanges();

                return new ServiceResult
                {
                    Succeed = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResult
                {
                    Succeed = false,
                    Error = e
                };
            }
        }

        public void Dispose() => GC.Collect();

        #endregion

        #region PROTECTED OVERRIDED METHODS

        protected override void EnsureDependencies()
        {
            if (_unitOfWorks == null)
                throw new ArgumentNullException($"{nameof(AuthorServiceFactory)} { UOW_ExceptionMessage }");
        }

        #endregion
    }
}
