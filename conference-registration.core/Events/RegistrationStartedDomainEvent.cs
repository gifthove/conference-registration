using conference_registration.core.Entities.RegistrationAggregate;
using MediatR;

namespace conference_registration.core.Events
{
    public class RegistrationStartedDomainEvent : INotification
    {
        public Registration Registration { get; }

        public RegistrationStartedDomainEvent(Registration registration)
        {
            this.Registration = registration;
        }
    }
}
