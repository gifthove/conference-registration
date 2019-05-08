// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAttendeeService.cs" company="Gift Ltd">
//   © Copyright 2019 - All rights reserved
// </copyright>
// <summary>
//   Defines the IAttendeeService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace conference_registration.ui.web.Interfaces
{
    using System.Collections.Generic;

    using conference_registration.core.Entities;
    using conference_registration.core.Entities.RegistrationAggregate;

    /// <summary>
    /// The AttendeeService interface.
    /// </summary>
    public interface IAttendeeService
    {
        /// <summary>
        /// The get attendee by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Attendee"/>.
        /// </returns>
        Attendee GetAttendeeById(int id);

        /// <summary>
        /// The get all attendees.
        /// </summary>
        /// <returns>
        /// The <see>
        ///         <cref>List</cref>
        ///     </see>
        ///     .
        /// </returns>
        List<Attendee> GetAllAttendees();

        /// <summary>
        /// The create attendee.
        /// </summary>
        /// <param name="attendee">
        /// The attendee.
        /// </param>
        void CreateAttendee(Attendee attendee);

        /// <summary>
        /// The update attendee.
        /// </summary>
        /// <param name="attendee">
        /// The attendee.
        /// </param>
        void UpdateAttendee(Attendee attendee);

        /// <summary>
        /// The delete attendee.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        void DeleteAttendee(int id);
    }
}
