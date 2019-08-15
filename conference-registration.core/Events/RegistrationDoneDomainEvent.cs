using conference_registration.core.Entities.RegistrationAggregate;
using MediatR;

namespace conference_registration.core.Events
{
    public class RegistrationDoneDomainEvent : INotification
    {
        public Registration Registration { get; }

        public RegistrationDoneDomainEvent(Registration registration)
        {
            Registration = registration;
        }
    }
}
