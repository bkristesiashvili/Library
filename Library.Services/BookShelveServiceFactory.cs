using static Library.Common.GlobalVariables;

using Library.Data.Repositories.Uow.Abstractions;
using Library.Services.Abstractions;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Library.Common.Responses;
using Library.Data.Entities;
using System.Linq;
using Library.Common.Requests.Filters.Abstractions;
using Library.Common.Enums;

namespace Library.Services
{
    public sealed class BookShelveServiceFactory : BaseService, IBookShelveService
    {
        #region CTOR

        public BookShelveServiceFactory(IUnitOfWorks uow)
            : base(uow) { }

        #endregion

        #region PUBLIC METHODS

        public void Dispose() => GC.Collect();

        public async Task<IQueryable<BookShelve>> GetAllBookShelveAsync(IFilter filter = null,
            bool selectDeleted = false)
        {
            EnsureDependencies();

            return selectDeleted
                ? await UnitOfWorks.BookShelvesRepository.GetAll(filter)
                : from shelve in await UnitOfWorks.BookShelvesRepository.GetAll(filter)
                  where !shelve.DeletedAt.HasValue
                  select shelve;

        }

        public async Task<BookShelve> GetBookShelveByIdAsync(Guid id)
        {
            EnsureDependencies();

            return await UnitOfWorks.BookShelvesRepository.GetByIdAsync(id);
        }

        public async Task<ServiceResult> CreateBookShelveAsync(BookShelve newBookSHelve)
        {
            try
            {
                EnsureDependencies();

                await UnitOfWorks.BookShelvesRepository.CreateAsync(newBookSHelve);
                UnitOfWorks.SaveChanges();

                return ServiceResult(true);
            }
            catch (Exception e)
            {

                return ServiceResult(false, e);
            }
        }

        public async Task<ServiceResult> UpdateBookShelveAsync(Guid id, BookShelve updatedBookShelve)
        {
            try
            {
                EnsureDependencies();

                var shelve = await GetBookShelveByIdAsync(id);

                if (shelve == null)
                    throw new Exception(RecordNotFound);

                shelve.Name = updatedBookShelve.Name;
                shelve.SectionId = updatedBookShelve.SectionId;

                await UnitOfWorks.BookShelvesRepository.UpdateAsync(shelve);
                UnitOfWorks.SaveChanges();

                return ServiceResult(true);
            }
            catch (Exception e)
            {
                return ServiceResult(false, e);
            }
        }

        public async Task<ServiceResult> DeleteBookShelveAsync(Guid id, DeletionType type = DeletionType.Soft)
        {
            try
            {
                EnsureDependencies();

                var shelve = await GetBookShelveByIdAsync(id);

                if (shelve == null)
                    throw new Exception(RecordNotFound);

                await UnitOfWorks.BookShelvesRepository.DeleteAsync(shelve, type);
                UnitOfWorks.SaveChanges();

                return ServiceResult(true);
            }
            catch (Exception e)
            {
                return ServiceResult(false, e);
            }
        }

        public async Task<ServiceResult> RestoreBookShelveAsync(Guid id)
        {
            try
            {
                EnsureDependencies();

                var shelve = await GetBookShelveByIdAsync(id);

                if (shelve == null)
                    throw new Exception(RecordNotFound);

                var fieldName = nameof(BookShelve.DeletedAt);

                var result = await UnitOfWorks.BookShelvesRepository.RestoreAsync(
                    shelve,
                    UnitOfWorks.BookShelvesRepository.Table, 
                    fieldName);

                if (result == null)
                    throw new Exception(RecordNotFound);

                return ServiceResult(true);
            }
            catch (Exception e)
            {
                return ServiceResult(false, e);
            }
        }

        #endregion

        #region PROTECTED METHODS

        protected override void EnsureDependencies()
        {
            if (UnitOfWorks == null)
                throw new ArgumentNullException(UOW_ExceptionMessage);
        }

        #endregion
    }
}
