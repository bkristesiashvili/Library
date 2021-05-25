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
    public interface IGenreService : IService
    {
        #region METHODS

        Task<IQueryable<Genre>> GetAllGenresAsync(IFilter filter = null);

        Task<Genre> GetGenreDetailByIdAsync(Guid id);

        Task<ServiceResult> CreateGenreAsync(Genre newGenre);

        Task<ServiceResult> EditGenreAsync(Guid id, Genre updatedGenre);

        Task<ServiceResult> DeleteGenreAsync(Guid id, DeletionType type = DeletionType.Soft);

        #endregion
    }
}
