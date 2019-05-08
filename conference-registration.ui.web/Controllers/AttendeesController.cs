// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AttendeesController.cs" company="Gift Ltd">
//   © Copyright 2019 - All rights reserved
// </copyright>
// <summary>
//   Defines the AttendeesController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace conference_registration.ui.web.Controllers
{
    using System.Collections.Generic;

    using conference_registration.core.Entities.RegistrationAggregate;
    using conference_registration.ui.web.Interfaces;

    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// The attendees controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AttendeesController : ControllerBase
    {
        /// <summary>
        /// The _attendee service.
        /// </summary>
        private readonly IAttendeeService _attendeeService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AttendeesController"/> class.
        /// </summary>
        /// <param name="attendeeService">
        /// The attendee service.
        /// </param>
        public AttendeesController(IAttendeeService attendeeService)
        {
            this._attendeeService = attendeeService;
        }

        // GET: api/Attendees

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
        public ActionResult<IEnumerable<Attendee>> Get()
        {
            return this._attendeeService.GetAllAttendees();
        }

        // GET: api/Attendees/5

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Attendee"/>.
        /// </returns>
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Attendee> Get(int id)
        {
            var attendee = this._attendeeService.GetAttendeeById(id);

            if (attendee == null)
            {
                return this.NotFound();
            }

            return attendee;
        }

        // POST: api/Attendees

        /// <summary>
        /// The post.
        /// </summary>
        /// <param name="Attendee">
        /// The attendee.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        public ActionResult<Attendee> Post([FromBody] Attendee Attendee)
        {
            this._attendeeService.CreateAttendee(Attendee);
            return this.Ok(Attendee);
        }

        // PUT: api/Attendees/5

        /// <summary>
        /// The put.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="Attendee">
        /// The attendee.
        /// </param>
        /// <returns>
        /// The <see cref="IActionResult"/>.
        /// </returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Attendee Attendee)
        {
            this._attendeeService.UpdateAttendee(Attendee);
            return this.Ok(Attendee); 
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
            var attendee = this._attendeeService.GetAttendeeById(id);

            if (attendee == null)
            {
                return this.NotFound();
            }

            this._attendeeService.DeleteAttendee(id); 

            return this.Ok();
        }
    }
}
