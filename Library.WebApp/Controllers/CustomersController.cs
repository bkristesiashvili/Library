using Library.Common.Requests.Filters;
using Library.Data.Extensions;
using Library.Services.Abstractions;
using Library.WebApp.Controllers.Abstractions;
using Library.WebApp.Helpers.Attributes;
using Library.WebApp.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WebApp.Controllers
{
    [Authorize]
    [ValidUser]
    public sealed class CustomersController : BaseController
    {
        #region PRIVATE FIELDS

        private readonly ICustomersService customersService;

        #endregion

        #region CTOR

        public CustomersController(IFileLoggerService logger,
            ICustomersService customersService)
            :base(logger) => this.customersService = customersService;

        #endregion

        #region ACTIONS

        public async Task<IActionResult> Index([FromQuery]CustomerFilter filter)
        {
            var customers = from customer in await customersService.GetAllCustomers(filter)
                            select new CustomersListViewModel
                            {
                                Id = customer.Id,
                                FirstName = customer.FirstName,
                                MiddleName = customer.MiddleName,
                                LastName = customer.LastName,
                                Email = customer.Email,
                                Phone = customer.Phone
                            };

            ViewBag.Search = filter.Search;
            ViewBag.Ordering = filter.Ordering;
            ViewBag.OrderBy = filter.OrderBy;

            return View(await customers.ToPagedListAsync(filter.Page, filter.PageSize));
        }

        #endregion
    }
}
