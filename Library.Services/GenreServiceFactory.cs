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
    public sealed class GenreServiceFactory : BaseService, IGenreService
    {
        #region PRIVATE FIELDS

        private readonly IUnitOfWorks _unitOfWorks;

        #endregion

        #region CTOR

        public GenreServiceFactory(IUnitOfWorks uow)
            => _unitOfWorks = uow;

        #endregion

        #region PUBLIC METHODS

        public async Task<ServiceResult> CreateGenreAsync(Genre newGenre)
        {
            try
            {
                EnsureDependencies();

                await _unitOfWorks.GenresRepository.CreateAsync(newGenre);
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

        public async Task<ServiceResult> DeleteGenreAsync(Guid id, DeletionType type = DeletionType.Soft)
        {
            try
            {
                EnsureDependencies();

                var genre = await GetGenreDetailByIdAsync(id);

                if (genre == null)
                    throw new Exception(RecordNotFound);

                await _unitOfWorks.GenresRepository.DeleteAsync(genre, type);
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

        public async Task<ServiceResult> EditGenreAsync(Guid id, Genre updatedGenre)
        {
            try
            {
                EnsureDependencies();

                var genre = await _unitOfWorks.GenresRepository.GetByIdAsync(id);

                if (genre == null)
                    throw new Exception(RecordNotFound);

                genre.Name = updatedGenre.Name;
                genre.UpdatedAt = DateTime.UtcNow;

                await _unitOfWorks.GenresRepository.UpdateAsync(genre);
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

        public async Task<IQueryable<Genre>> GetAllGenresAsync(IFilter filter = null)
        {
            EnsureDependencies();

            return await _unitOfWorks.GenresRepository.GetAll(filter);
        }

        public async Task<Genre> GetGenreDetailByIdAsync(Guid id)
        {
            EnsureDependencies();

            return await _unitOfWorks.GenresRepository.GetByIdAsync(id);
        }

        public void Dispose() => GC.Collect();

        #endregion

        #region PROTECTED OVERRIDED METHODS

        protected override void EnsureDependencies()
        {
            if (_unitOfWorks == null)
                throw new ArgumentNullException(UOW_ExceptionMessage);
        }

        #endregion
    }
}
