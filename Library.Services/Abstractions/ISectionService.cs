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
    public interface ISectionService : IService
    {
        #region METHODS

        Task<IQueryable<Section>> GetAllSectionsAsync(IFilter filter = null, bool selectDeleted = false);

        Task<Section> GetSectionByIdAsync(Guid id);

        Task<ServiceResult> CreateSectionAsync(Section newSection);

        Task<ServiceResult> UpdateSectionAsync(Guid id, Section updatedSection);

        Task<ServiceResult> DeleteSectionAsync(Guid id, DeletionType type = DeletionType.Soft);

        Task<ServiceResult> RestoreSectionAsync(Guid id);

        #endregion
    }
}
