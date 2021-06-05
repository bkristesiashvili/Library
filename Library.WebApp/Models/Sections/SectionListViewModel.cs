﻿using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WebApp.Models
{
    public sealed class SectionListViewModel
    {
        #region PUBLIC PROPERTIES

        [HiddenInput]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string CreateDate { get; set; }

        public string SectorName { get; set; }

        public Guid SectorId { get; set; }

        public bool IsDeleted { get; set; }

        #endregion
    }
}