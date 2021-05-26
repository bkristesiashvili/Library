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
        #region CTOR

        public GenreServiceFactory(IUnitOfWorks uow)
            : base(uow) { }

        #endregion

        #region PUBLIC METHODS

        public async Task<ServiceResult> CreateGenreAsync(Genre newGenre)
        {
            try
            {
                EnsureDependencies();

                await UnitOfWorks.GenresRepository.CreateAsync(newGenre);
                UnitOfWorks.SaveChanges();

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

                await UnitOfWorks.GenresRepository.DeleteAsync(genre, type);
                UnitOfWorks.SaveChanges();

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

                var genre = await UnitOfWorks.GenresRepository.GetByIdAsync(id);

                if (genre == null)
                    throw new Exception(RecordNotFound);

                genre.Name = updatedGenre.Name;

                await UnitOfWorks.GenresRepository.UpdateAsync(genre);
                UnitOfWorks.SaveChanges();

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

            return await UnitOfWorks.GenresRepository.GetAll(filter);
        }

        public async Task<Genre> GetGenreDetailByIdAsync(Guid id)
        {
            EnsureDependencies();

            return await UnitOfWorks.GenresRepository.GetByIdAsync(id);
        }

        public void Dispose() => GC.Collect();

        #endregion

        #region PROTECTED OVERRIDED METHODS

        protected override void EnsureDependencies()
        {
            if (UnitOfWorks == null)
                throw new ArgumentNullException(UOW_ExceptionMessage);
        }

        #endregion
    }
}
