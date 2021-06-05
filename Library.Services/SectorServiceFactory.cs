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
    public sealed class SectorServiceFactory : BaseService, ISectorService
    {
        #region CTOR

        public SectorServiceFactory(IUnitOfWorks uow)
            : base(uow) { }

        #endregion

        #region PUBLIC METHODS

        public void Dispose() => GC.Collect();

        public async Task<IQueryable<Sector>> GetAllSectorsAsync(IFilter filter = null,
            bool selectDeleted = false)
        {
            EnsureDependencies();

            return selectDeleted
                ? await UnitOfWorks.SectorsRepository.GetAll(filter)
                : from sector in await UnitOfWorks.SectorsRepository.GetAll(filter)
                  where !sector.DeletedAt.HasValue
                  select sector;
        }

        public async Task<Sector> GetsSectorDetailsByIdAsync(Guid id)
        {
            EnsureDependencies();

            return await UnitOfWorks.SectorsRepository.GetByIdAsync(id);
        }

        public async Task<ServiceResult> UpdateSectorAsync(Guid id, Sector updatedSector)
        {
            try
            {
                EnsureDependencies();

                var sector = await GetsSectorDetailsByIdAsync(id);

                if (sector == null)
                    throw new Exception(RecordNotFound);

                sector.Name = updatedSector.Name;

                await UnitOfWorks.SectorsRepository.UpdateAsync(sector);
                UnitOfWorks.SaveChanges();

                return ServiceResult(true);
            }
            catch (Exception e)
            {

                return ServiceResult(false, e);
            }
        }

        public async Task<ServiceResult> CreateSectorAsync(Sector newSector)
        {
            try
            {
                EnsureDependencies();

                if (!RestoreIfExistsWhenCreate(newSector.Name, await GetAllSectorsAsync()))
                {
                    await UnitOfWorks.SectorsRepository.CreateAsync(newSector);
                    UnitOfWorks.SaveChanges();
                }

                return ServiceResult(true);
            }
            catch (Exception e)
            {
                return ServiceResult(false, e);
            }
        }

        public async Task<ServiceResult> DeleteSectorAsync(Guid id, DeletionType type = DeletionType.Soft)
        {
            try
            {
                EnsureDependencies();

                var sector = await GetsSectorDetailsByIdAsync(id);

                if (sector == null)
                    throw new Exception(RecordNotFound);

                if (sector.Sections.Any())
                    throw new Exception(string.Format(DataLostMessage, "თაროს"));

                await UnitOfWorks.SectorsRepository.DeleteAsync(sector);
                UnitOfWorks.SaveChanges();

                return ServiceResult(true);
            }
            catch (Exception e)
            {
                return ServiceResult(false, e);
            }
        }

        public async Task<ServiceResult> RestoreSectorAsync(Guid id)
        {
            try
            {
                EnsureDependencies();

                var deletedSector = await GetsSectorDetailsByIdAsync(id);

                if (deletedSector == null)
                    throw new Exception(RecordNotFound);

                deletedSector.DeletedAt = null;

                await UnitOfWorks.SectorsRepository.UpdateAsync(deletedSector);
                UnitOfWorks.SaveChanges();

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

        #region PRIVATE METHODS

        private bool RestoreIfExistsWhenCreate(string Name, IEnumerable<Sector> sectors)
        {
            if (sectors == null)
                throw new ArgumentNullException(nameof(sectors));

            var found = sectors.FirstOrDefault(s => s.Name.Equals(Name));

            if (found == null) return false;

            if (found.DeletedAt.HasValue)
                return RestoreSectorAsync(found.Id).Result.Succeed;
            else
                throw new Exception(RecordAlreadyExists);
        }

        #endregion
    }
}
