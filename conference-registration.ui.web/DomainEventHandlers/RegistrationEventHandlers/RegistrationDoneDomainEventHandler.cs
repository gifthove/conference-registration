using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using conference_registration.core.Entities.RegistrationAggregate;
using conference_registration.core.Events;
using conference_registration.core.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace conference_registration.ui.web.DomainEventHandlers.RegistrationEventHandlers
{
    public class RegistrationDoneDomainEventHandler : INotificationHandler<RegistrationDoneDomainEvent>
    {
        private readonly IRepository<Registration> _registrationRepository;

        public RegistrationDoneDomainEventHandler(IRepository<Registration> registrationRepository)
        {
            _registrationRepository = registrationRepository;
        }

        public Task Handle(RegistrationDoneDomainEvent notification, CancellationToken cancellationToken)
        {
           return  Task.Run(() =>Debug.WriteLine("event fired"));
        }
    }
}
