// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegistrationDoneDomainEvent.cs" company="Gift Ltd">
//   © Copyright 2019 - All rights reserved
// </copyright>
// <summary>
//   Defines the RegistrationDoneDomainEvent type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace conference_registration.core.Events
{
    using conference_registration.core.Entities.RegistrationAggregate;

    using MediatR;

    /// <summary>
    /// The registration done domain event.
    /// </summary>
    public class RegistrationDoneDomainEvent : INotification
    {
        /// <summary>
        /// Gets the registration.
        /// </summary>
        public Registration Registration { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegistrationDoneDomainEvent"/> class.
        /// </summary>
        /// <param name="registration">
        /// The registration.
        /// </param>
        public RegistrationDoneDomainEvent(Registration registration)
        {
            this.Registration = registration;
        }
    }
}
