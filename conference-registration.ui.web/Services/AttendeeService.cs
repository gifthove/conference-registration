// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AttendeeService.cs" company="Gift Ltd">
//   © Copyright 2019 - All rights reserved
// </copyright>
// <summary>
//   The attendee service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace conference_registration.ui.web.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using common;
    using core.Entities.RegistrationAggregate;
    using conference_registration.core.Interfaces;
    using Interfaces;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The attendee service.
    /// </summary>
    public class AttendeeService : IAttendeeService
    {
        /// <summary>
        /// The _logger.
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// The _attendee repository.
        /// </summary>
        private readonly IRepository<Attendee> _attendeeRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AttendeeService"/> class.
        /// </summary>
        /// <param name="attendeeRepository">
        /// The attendee repository.
        /// </param>
        /// <param name="logger">
        /// The logger.
        /// </param>
        public AttendeeService(IRepository<Attendee> attendeeRepository, ILogger<AttendeeService> logger)
        {
            this._attendeeRepository = attendeeRepository;
            this._logger = logger;
        }

        /// <summary>
        /// The get attendee by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Attendee"/>.
        /// </returns>
        public Attendee GetAttendeeById(int id)
        {
            this._logger.LogInformation(LoggingEvents.GetItem, "Getting item {ID}", id);
            var attendee = this._attendeeRepository.GetById(id);
            if (attendee != null) return attendee;
            this._logger.LogWarning(LoggingEvents.GetItemNotFound, "GetAttendeeById({ID}) NOT FOUND", id);
            return null;
        }

        /// <summary>
        /// The get all attendees.
        /// </summary>
        /// <returns>
        /// The <see>
        ///         <cref>List</cref>
        ///     </see>
        ///     .
        /// </returns>
        public List<Attendee> GetAllAttendees()
        {
            this._logger.LogInformation(LoggingEvents.ListItems, "Get all attendees");
            return this._attendeeRepository.List().ToList();
        }

        /// <summary>
        /// The create attendee.
        /// </summary>
        /// <param name="attendee">
        /// The attendee.
        /// </param>
        public void CreateAttendee(Attendee attendee)
        {
            this._logger.LogInformation(LoggingEvents.InsertItem, "Create Attendee");
            this._attendeeRepository.Insert(attendee);
        }

        /// <summary>
        /// The update attendee.
        /// </summary>
        /// <param name="attendee">
        /// The attendee.
        /// </param>
        public void UpdateAttendee(Attendee attendee)
        {
            this._logger.LogInformation(LoggingEvents.UpdateItem, "Update Attendee");
            this._attendeeRepository.Update(attendee);
        }

        /// <summary>
        /// The delete attendee.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public void DeleteAttendee(int id)
        {
            this._logger.LogInformation(LoggingEvents.DeleteItem, "Delete Attendee");
            this._attendeeRepository.Delete(id);
        }
    }
}
