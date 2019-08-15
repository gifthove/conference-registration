// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegistrationsController.cs" company="Gift Ltd">
//   © Copyright 2019 - All rights reserved
// </copyright>
// <summary>
//   Defines the RegistrationsController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using conference_registration.core.Paging;

namespace conference_registration.ui.web.Controllers
{
    using core.Entities.RegistrationAggregate;
    using Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using System.Collections.Generic;
    using ViewModel;

    /// <summary>
    /// The registrations controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationsController : ControllerBase
    {
        /// <summary>
        /// The _registration service.
        /// </summary>
        private readonly IRegistrationService _registrationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegistrationsController"/> class.
        /// </summary>
        /// <param name="registrationService">
        /// The registration service.
        /// </param>
        public RegistrationsController(IRegistrationService registrationService)
        {
            this._registrationService = registrationService;
        }

        // GET: api/Registrations

        /// <summary>
        /// The get.
        /// </summary>
        /// <returns>
        /// The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        ///     .
        /// </returns>
        [HttpGet]
        public ActionResult<IEnumerable<RegistrationViewModel>> Get()
        {
            return this._registrationService.GetAllRegistrations();
        }

        // GET: api/Registrations

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="searchModel">
        /// The search Model.
        /// </param>
        /// <returns>
        /// The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        ///     .
        /// </returns>
        [Route("SearchRegistrations")]
        [HttpPost]
        public ActionResult<PagedList<RegistrationViewModel>> SearchRegistrations(SearchModel searchModel)
        {
            return this._registrationService.GetPagedRegistrations(searchModel);
        }

        // POST: api/Registrations

        /// <summary>
        /// The post.
        /// </summary>
        /// <param name="Registration">
        /// The registration.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        public ActionResult<Registration> Post([FromBody] RegistrationViewModel Registration)
        {
            this._registrationService.CreateRegistration(Registration);
            return this.Ok(Registration);
        }

        // PUT: api/Registrations/5

        /// <summary>
        /// The put.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="Registration">
        /// The registration.
        /// </param>
        /// <returns>
        /// The <see cref="IActionResult"/>.
        /// </returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] RegistrationViewModel Registration)
        {
            this._registrationService.UpdateRegistration(Registration);
            return this.Ok(Registration);
        }
    }
}
