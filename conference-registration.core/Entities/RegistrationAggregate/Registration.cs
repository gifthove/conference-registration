// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Registration.cs" company="Gift Ltd">
//   © Copyright 2019 - All rights reserved
// </copyright>
// <summary>
//   The registration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace conference_registration.core.Entities.RegistrationAggregate
{
    using System.Collections.Generic;
    using System.Linq;
    using conference_registration.core.Interfaces;

    /// <summary>
    /// The registration.
    /// </summary>
    public class Registration : BaseEntity, IAggregateRoot
    {

        /// <summary>
        /// Gets or sets the attendee id.
        /// </summary>
        public int AttendeeId { get; set; }

        /// <summary>
        /// Gets or sets the attendee.
        /// </summary>
        public Attendee Attendee { get; set; }

        /// <summary>
        /// Gets or sets the conference id.
        /// </summary>
        public int ConferenceId { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        private readonly List<AttendeeSessionRegistration> _attendingSessions = new List<AttendeeSessionRegistration>();

        /// <summary>
        /// 
        /// </summary>
        public IReadOnlyCollection<AttendeeSessionRegistration> AttendingSessions => _attendingSessions.AsReadOnly();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="attendingSessions"></param>
        public void AddAttendeeSessionRegistration(List<AttendeeSessionRegistration> attendingSessions)
        {
            if (ConferenceId == 0)
            {
                // Can not Add 
                return;
            }

            foreach (var session in attendingSessions)
            {
                if (this._attendingSessions.Any(a => a.SessionId == session.Id))
                {
                    // already registered;
                    continue;
                }
                this._attendingSessions.Add(new AttendeeSessionRegistration() { SessionId = session.SessionId });
            }
        }

    }
}
