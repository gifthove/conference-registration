// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegistrationViewModel.cs" company="Gift Ltd">
//   © Copyright 2019 - All rights reserved
// </copyright>
// <summary>
//   Defines the RegistrationViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace conference_registration.ui.web.ViewModel
{
    using System.Collections.Generic;

    using conference_registration.core.Entities.RegistrationAggregate;

    /// <summary>
    /// The registration view model.
    /// </summary>
    public class RegistrationViewModel
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the attendee.
        /// </summary>
        public Attendee Attendee { get; set; }

        /// <summary>
        /// Gets or sets the conference id.
        /// </summary>
        public int ConferenceId { get; set; }

        /// <summary>
        /// Gets or sets the conference sessions.
        /// </summary>
        public ICollection<AttendeeSessionRegistration> AttendingSessions { get; set; }
    }
}
