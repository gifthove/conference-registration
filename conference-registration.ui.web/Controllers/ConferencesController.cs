// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConferencesController.cs" company="Gift Ltd">
//   © Copyright 2019 - All rights reserved
// </copyright>
// <summary>
//   Defines the ConferencesController type.
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
    /// The attendees controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ConferencesController : ControllerBase
    {
        /// <summary>
        /// The _attendee service.
        /// </summary>
        private readonly IConferenceService _conferenceService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConferencesController"/> class.
        /// </summary>
        /// <param name="conferenceService">
        /// The attendee service.
        /// </param>
        public ConferencesController(IConferenceService conferenceService)
        {
            this._conferenceService = conferenceService;
        }

        // GET: api/Conferences

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
        public ActionResult<IEnumerable<Conference>> Get()
        {
            return this._conferenceService.GetAllConferences();
        }

        // GET: api/Conference/5

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpGet("{id}", Name = "GetConference")]
        public ActionResult<Conference> Get(int id)
        {
            return this._conferenceService.GetConferenceById(id);
        }

        // POST: api/Conferences

        /// <summary>
        /// The post.
        /// </summary>
        /// <param name="Conference">
        /// The attendee.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        public ActionResult<Conference> Post([FromBody] Conference Conference)
        {
            this._conferenceService.CreateConference(Conference);
            return this.Ok(Conference);
        }

        // PUT: api/Conferences/5

        /// <summary>
        /// The put.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="Conference">
        /// The attendee.
        /// </param>
        /// <returns>
        /// The <see cref="IActionResult"/>.
        /// </returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Conference Conference)
        {
            this._conferenceService.UpdateConference(Conference);
            return this.Ok(Conference); 
        }

        // DELETE: api/ApiWithActions/5

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="IActionResult"/>.
        /// </returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var attendee = this._conferenceService.GetConferenceById(id);

            if (attendee == null)
            {
                return this.NotFound();
            }

            // Test
            this._conferenceService.DeleteConference(id); 

            return this.Ok();
        }
    }
}
