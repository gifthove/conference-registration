// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegistrationStartedDomainEvent.cs" company="Gift Ltd">
//   © Copyright 2019 - All rights reserved
// </copyright>
// <summary>
//   Defines the RegistrationStartedDomainEvent type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace conference_registration.core.Events
{
    using conference_registration.core.Entities.RegistrationAggregate;

    using MediatR;

    /// <summary>
    /// The registration started domain event.
    /// </summary>
    public class RegistrationStartedDomainEvent : INotification
    {
        /// <summary>
        /// Gets the registration.
        /// </summary>
        public Registration Registration { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegistrationStartedDomainEvent"/> class.
        /// </summary>
        /// <param name="registration">
        /// The registration.
        /// </param>
        public RegistrationStartedDomainEvent(Registration registration)
        {
            this.Registration = registration;
        }
    }
}
