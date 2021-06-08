using static Library.Common.GlobalVariables;

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
using Library.Common.Enums;

namespace Library.Services
{
    public sealed class SectionServiceFactory : BaseService, ISectionService
    {
        #region CTOR

        public SectionServiceFactory(IUnitOfWorks ouw)
            : base(ouw) { }

        #endregion

        #region PUBLIC METHODS

        public void Dispose() => GC.Collect();

        public async Task<IQueryable<Section>> GetAllSectionsAsync(IFilter filter = null, 
            bool selectDeleted = false)
        {
            EnsureDependencies();

            return selectDeleted
                ? await UnitOfWorks.SectionsRepository.GetAll(filter)
                : from section in await UnitOfWorks.SectionsRepository.GetAll(filter)
                  where !section.DeletedAt.HasValue
                  select section;
        }

        public async Task<Section> GetSectionByIdAsync(Guid id)
        {
            EnsureDependencies();

            return await UnitOfWorks.SectionsRepository.GetByIdAsync(id);
        }

        public async Task<ServiceResult> RestoreSectionAsync(Guid id)
        {
            try
            {
                var section = await GetSectionByIdAsync(id);

                if (section == null)
                    throw new Exception(RecordNotFound);

                var tableName = $"{nameof(Section)}s";
                var fieldName = nameof(Section.DeletedAt);

                var result = await UnitOfWorks.SectionsRepository.RestoreAsync(section, tableName, fieldName);

                if (result == null)
                    throw new Exception(RecordNotFound);

                return ServiceResult(true);
            }
            catch (Exception e)
            {
                return ServiceResult(false, e);
            }
        }

        public async Task<ServiceResult> UpdateSectionAsync(Guid id, Section updatedSection)
        {
            try
            {
                EnsureDependencies();

                var section = await GetSectionByIdAsync(id);

                if (section == null)
                    throw new Exception(RecordNotFound);

                var sector = await UnitOfWorks.SectorsRepository
                    .GetByIdAsync(section.SectorId);

                var exists = sector.Sections.Select(s => s.Name);

                if (exists.Contains(updatedSection.Name))
                    throw new Exception(RecordAlreadyExists);

                section.Name = updatedSection.Name;
                section.SectorId = updatedSection.SectorId;

                await UnitOfWorks.SectionsRepository.UpdateAsync(section);
                UnitOfWorks.SaveChanges();

                return ServiceResult(true);
            }
            catch (Exception e)
            {
                return ServiceResult(false, e);
            }
        }

        public async Task<ServiceResult> CreateSectionAsync(Section newSection)
        {
            try
            {
                EnsureDependencies();

                var currentSector = await UnitOfWorks.SectorsRepository
                    .GetByIdAsync(newSection.SectorId);

                var exists = currentSector.Sections
                    .Select(section => section);

                if (!RestoreIfExistWhenCreate(newSection.Name, exists))
                {
                    await UnitOfWorks.SectionsRepository.CreateAsync(newSection);
                    UnitOfWorks.SaveChanges();
                }

                return ServiceResult(true);
            }
            catch (Exception e)
            {

                return ServiceResult(false, e);
            }
        }

        public async Task<ServiceResult> DeleteSectionAsync(Guid id, DeletionType type = DeletionType.Soft)
        {
            try
            {
                EnsureDependencies();

                var section = await GetSectionByIdAsync(id);

                if (section == null)
                    throw new Exception(RecordNotFound);

                if (section.BookShelves.Any())
                    throw new Exception(string.Format(DataLostMessage, "კარადის"));

                await UnitOfWorks.SectionsRepository.DeleteAsync(section);
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

        private bool RestoreIfExistWhenCreate(string Name, IEnumerable<Section> relatedSections)
        {
            if (relatedSections == null)
                throw new ArgumentNullException(nameof(relatedSections));

            var found = relatedSections.FirstOrDefault(s => s.Name.Equals(Name));

            if (found == null) return false;

            if (found.DeletedAt.HasValue)
                return RestoreSectionAsync(found.Id).Result.Succeed;
            else
                throw new Exception(RecordAlreadyExists);
        }

        #endregion
    }
}
