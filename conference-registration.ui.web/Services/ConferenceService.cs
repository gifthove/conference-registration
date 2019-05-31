// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConferenceService.cs" company="Gift Ltd">
//   © Copyright 2019 - All rights reserved
// </copyright>
// <summary>
//   The attendee service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace conference_registration.ui.web.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using conference_registration.common;
    using conference_registration.core.Entities;
    using conference_registration.core.Entities.ConferenceAggregate;
    using conference_registration.core.Entities.RegistrationAggregate;
    using conference_registration.core.Interfaces;
    using conference_registration.ui.web.Interfaces;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The attendee service.
    /// </summary>
    public class ConferenceService : IConferenceService
    {
        /// <summary>
        /// The _logger.
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// The _attendee repository.
        /// </summary>
        private readonly IRepository<Conference> _conferenceRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConferenceService"/> class.
        /// </summary>
        /// <param name="conferenceRepository">
        /// The attendee repository.
        /// </param>
        /// <param name="logger">
        /// The logger.
        /// </param>
        public ConferenceService(IRepository<Conference> conferenceRepository, ILogger<ConferenceService> logger)
        {
            this._conferenceRepository = conferenceRepository;
            this._logger = logger;
        }

        /// <summary>
        /// The get attendee by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Conference"/>.
        /// </returns>
        public Conference GetConferenceById(int id)
        {
            this._logger.LogInformation(LoggingEvents.GetItem, "Getting item {ID}", id);
            var attendee = this._conferenceRepository.GetById(id);
            if (attendee != null) return attendee;
            this._logger.LogWarning(LoggingEvents.GetItemNotFound, "GetConferenceById({ID}) NOT FOUND", id);
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
        public List<Conference> GetAllConferences()
        {
            this._logger.LogInformation(LoggingEvents.ListItems, "Get all attendees");
            return this._conferenceRepository.List().ToList();
        }

        /// <summary>
        /// The create attendee.
        /// </summary>
        /// <param name="attendee">
        /// The attendee.
        /// </param>
        public void CreateConference(Conference attendee)
        {
            this._logger.LogInformation(LoggingEvents.InsertItem, "Create Conference");
            this._conferenceRepository.Insert(attendee);
        }

        /// <summary>
        /// The update attendee.
        /// </summary>
        /// <param name="attendee">
        /// The attendee.
        /// </param>
        public void UpdateConference(Conference attendee)
        {
            this._logger.LogInformation(LoggingEvents.UpdateItem, "Update Conference");
            this._conferenceRepository.Update(attendee);
        }

        /// <summary>
        /// The delete attendee.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public void DeleteConference(int id)
        {
            this._logger.LogInformation(LoggingEvents.DeleteItem, "Delete Conference");
            this._conferenceRepository.Delete(id);
        }

        /// <summary>
        /// The get session by conference id.
        /// </summary>
        /// <param name="ConferenceId">
        /// The conference id.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<Session> GetSessionByConferenceId(int ConferenceId)
        {
            return this.GetConferenceById(ConferenceId)?.Sessions?.ToList();
        }
    }
}
