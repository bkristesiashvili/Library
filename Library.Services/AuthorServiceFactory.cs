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
        #region CTOR

        //CTOR
        public AuthorServiceFactory(IUnitOfWorks uow)
            : base(uow) { }

        #endregion

        #region PUBLIC METHODS

        public async Task<IQueryable<Author>> GetAllAuthorsAsync(IFilter filter = null
            , bool selectDeleted = false)
        {
            EnsureDependencies();

            return selectDeleted
                ? await UnitOfWorks.AuthorsRepository.GetAll(filter)
                : from author in await UnitOfWorks.AuthorsRepository.GetAll(filter)
                  where !author.DeletedAt.HasValue
                  select author;
        }

        public async Task<Author> GetAuthorDetailsByIdAsync(Guid id)
        {
            EnsureDependencies();

            return await UnitOfWorks.AuthorsRepository.GetByIdAsync(id);
        }

        public async Task<ServiceResult> CreateNewAuthorAsync(Author newAuthor)
        {
            try
            {
                EnsureDependencies();

                await UnitOfWorks.AuthorsRepository.CreateAsync(newAuthor);
                UnitOfWorks.SaveChanges();

                return ServiceResult(true);
            }
            catch(Exception e)
            {
                return ServiceResult(false, e);
            }
        }

        public async Task<ServiceResult> EditAuthorInfoAsync(Guid id, Author updatedAuthor)
        {
            try
            {


                var existed = await GetAuthorDetailsByIdAsync(id);

                if (existed == null)
                    throw new Exception(RecordNotFound);

                existed.FirstName = updatedAuthor.FirstName;
                existed.MiddleName = updatedAuthor.MiddleName;
                existed.LastName = updatedAuthor.LastName;

                await UnitOfWorks.AuthorsRepository.UpdateAsync(existed);
                UnitOfWorks.SaveChanges();

                return ServiceResult(true);
            }
            catch (Exception e)
            {
                return ServiceResult(false, e);
            }
        }

        public async Task<ServiceResult> DeleteAuthorInfoAsync(Guid id, DeletionType type = DeletionType.Soft)
        {
            try
            {
                EnsureDependencies();

                var existed = await GetAuthorDetailsByIdAsync(id);

                if (existed == null)
                    throw new Exception(RecordNotFound);

                await UnitOfWorks.AuthorsRepository.DeleteAsync(existed, type);
                UnitOfWorks.SaveChanges();

                return ServiceResult(true);
            }
            catch (Exception e)
            {
                return ServiceResult(false, e);
            }
        }

        public async Task<ServiceResult> RestoreAuthorAsync(Guid id)
        {
            try
            {
                EnsureDependencies();

                var author = await GetAuthorDetailsByIdAsync(id);

                if (author == null)
                    throw new Exception(RecordNotFound);

                var fieldname = nameof(Author.DeletedAt);

                var result = await UnitOfWorks.AuthorsRepository.RestoreAsync(
                    author, 
                    UnitOfWorks.AuthorsRepository.Table, 
                    fieldname);

                if (result == null)
                    throw new Exception(RecordNotFound);

                return ServiceResult(true);
            }
            catch (Exception e)
            {
                return ServiceResult(false, e);
            }
        }

        public void Dispose() => GC.Collect();

        #endregion

        #region PROTECTED OVERRIDED METHODS

        protected override void EnsureDependencies()
        {
            if (UnitOfWorks == null)
                throw new ArgumentNullException($"{nameof(AuthorServiceFactory)} { UOW_ExceptionMessage }");
        }

        #endregion
    }
}
