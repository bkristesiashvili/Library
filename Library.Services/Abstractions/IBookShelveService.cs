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
    public interface IBookShelveService : IService
    {
        #region METHODS

        Task<IQueryable<BookShelve>> GetAllBookShelveAsync(IFilter filter = null,
            bool selectDeleted = false);

        Task<BookShelve> GetBookShelveByIdAsync(Guid id);

        Task<ServiceResult> CreateBookShelveAsync(BookShelve newBookSHelve);

        Task<ServiceResult> UpdateBookShelveAsync(Guid id, BookShelve updatedBookShelve);

        Task<ServiceResult> DeleteBookShelveAsync(Guid id, DeletionType type = DeletionType.Soft);

        Task<ServiceResult> RestoreBookShelveAsync(Guid id);

        #endregion
    }
}
