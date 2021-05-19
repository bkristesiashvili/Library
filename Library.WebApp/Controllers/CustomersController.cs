using Library.Services.Abstractions;
using Library.WebApp.Controllers.Abstractions;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WebApp.Controllers
{
    public sealed class CustomersController : BaseController
    {
        #region PRIVATE FIELDS

        private readonly ICustomersService customersService;

        #endregion

        #region CTOR

        public CustomersController(IFileLogger logger,
            ICustomersService customersService)
            :base(logger) => this.customersService = customersService;

        #endregion

        public IActionResult Index()
        {
            return View();
        }
    }
}
