﻿using Library.Common.Enums;
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
    public interface ISectorService : IService
    {
        #region METHODS

        Task<IQueryable<Sector>> GetAllSectorsAsync(IFilter filter = null);

        Task<Sector> GetsSectorDetailsByIdAsync(Guid id);

        Task<ServiceResult> CreateSectorAsync(Sector newSector);

        Task<ServiceResult> UpdateSectorAsync(Sector updatedSector);

        Task<ServiceResult> DeleteSectorAsync(Sector deleteSector, DeletionType type = DeletionType.Soft);

        #endregion
    }
}
