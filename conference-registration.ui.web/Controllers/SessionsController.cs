// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SessionsController.cs" company="Gift Ltd">
//   © Copyright 2019 - All rights reserved
// </copyright>
// <summary>
//   Defines the SessionsController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace conference_registration.ui.web.Controllers
{
    using System.Collections.Generic;

    using conference_registration.core.Entities.ConferenceAggregate;
    using conference_registration.ui.web.Interfaces;

    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// The conferences controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        /// <summary>
        /// The _conference service.
        /// </summary>
        private readonly IConferenceService _conferenceService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SessionsController"/> class.
        /// </summary>
        /// <param name="conferenceService">
        /// The conference service.
        /// </param>
        public SessionsController(IConferenceService conferenceService)
        {
            this._conferenceService = conferenceService;
        }

        // GET: api/Sessions/5

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Session"/>.
        /// </returns>
        [HttpGet]
        [Route("sessionsforconference/{id}")]
        public ActionResult<IEnumerable<Session>> GetSessionsForConference(int id)
        {
            var sessions = this._conferenceService.GetSessionByConferenceId(id);
            return this.Ok(sessions);
        }
    }
}
