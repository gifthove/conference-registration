// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IConferenceService.cs" company="Gift Ltd">
//   © Copyright 2019 - All rights reserved
// </copyright>
// <summary>
//   Defines the IConferenceService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace conference_registration.ui.web.Interfaces
{
    using System.Collections.Generic;

    using conference_registration.core.Entities.ConferenceAggregate;

    /// <summary>
    /// The ConferenceService interface.
    /// </summary>
    public interface IConferenceService
    {
        /// <summary>
        /// The get conference by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Conference"/>.
        /// </returns>
        Conference GetConferenceById(int id);

        /// <summary>
        /// The get all conferences.
        /// </summary>
        /// <returns>
        /// The <see>
        ///         <cref>List</cref>
        ///     </see>
        ///     .
        /// </returns>
        List<Conference> GetAllConferences();

        /// <summary>
        /// The create conference.
        /// </summary>
        /// <param name="conference">
        /// The conference.
        /// </param>
        void CreateConference(Conference conference);

        /// <summary>
        /// The update conference.
        /// </summary>
        /// <param name="conference">
        /// The conference.
        /// </param>
        void UpdateConference(Conference conference);

        /// <summary>
        /// The delete conference.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        void DeleteConference(int id);

        /// <summary>
        /// The get session by conference id.
        /// </summary>
        /// <param name="ConferenceId">
        /// The conference id.
        /// </param>
        /// <returns>
        /// The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        ///     .
        /// </returns>
        IEnumerable<Session> GetSessionByConferenceId(int ConferenceId);
    }
}
