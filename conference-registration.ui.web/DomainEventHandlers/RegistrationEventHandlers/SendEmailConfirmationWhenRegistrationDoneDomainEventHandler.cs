using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using conference_registration.core.Events;
using conference_registration.core.Interfaces;
using conference_registration.ui.web.Factories;
using MediatR;

namespace conference_registration.ui.web.DomainEventHandlers.RegistrationEventHandlers
{
    public class SendEmailConfirmationWhenRegistrationDoneDomainEventHandler : INotificationHandler<RegistrationDoneDomainEvent>
    {
        private readonly IEmailModelFactories _emailModelFactories;
        private readonly IEmailSender _emailSender;

        public SendEmailConfirmationWhenRegistrationDoneDomainEventHandler(IEmailModelFactories emailModelFactories, IEmailSender emailSender)
        {
            _emailModelFactories = emailModelFactories;
            _emailSender = emailSender;
        }

        public Task Handle(RegistrationDoneDomainEvent notification, CancellationToken cancellationToken)
        {
           return  Task.Run(() =>
           {
               Debug.WriteLine("event fired");
               var emailAccount = _emailModelFactories.PrepareEmailAccountModel();

                _emailSender.SendEmail(emailAccount.EmailAccount,
                    "Test", 
                    "First thing first",
                    "gifthove@gmail.com",
                    "Gift",
                    "gifthov@gmail.com",
                    "Gift");

           }, cancellationToken);
        }
    }
}
