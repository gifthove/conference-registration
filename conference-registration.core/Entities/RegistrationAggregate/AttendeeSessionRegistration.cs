// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AttendeeSessionRegistration.cs" company="Gift Ltd">
//   © Copyright 2019 - All rights reserved
// </copyright>
// <summary>
//   Defines the AttendeeSessionRegistration type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace conference_registration.core.Entities.RegistrationAggregate
{
    using ConferenceAggregate;

    /// <summary>
    /// The attending session registration.
    /// </summary>
    public class AttendeeSessionRegistration : BaseEntity
    {
        /// <summary>
        /// Gets or sets the session id.
        /// </summary>
        public int SessionId { get; set; }

        /// <summary>
        /// Gets or sets the session.
        /// </summary>
        public Session Session { get; set; }
    }
}
