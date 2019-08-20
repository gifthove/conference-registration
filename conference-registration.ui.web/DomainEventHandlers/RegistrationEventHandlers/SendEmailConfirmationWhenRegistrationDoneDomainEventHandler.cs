// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SendEmailConfirmationWhenRegistrationDoneDomainEventHandler.cs" company="Gift Ltd">
//   © Copyright 2019 - All rights reserved
// </copyright>
// <summary>
//   Defines the SendEmailConfirmationWhenRegistrationDoneDomainEventHandler type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace conference_registration.ui.web.DomainEventHandlers.RegistrationEventHandlers
{
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;

    using conference_registration.core.Events;
    using conference_registration.core.Interfaces;
    using conference_registration.ui.web.Factories;

    using MediatR;

    /// <summary>
    /// The send email confirmation when registration done domain event handler.
    /// </summary>
    public class SendEmailConfirmationWhenRegistrationDoneDomainEventHandler : INotificationHandler<RegistrationDoneDomainEvent>
    {
        /// <summary>
        /// The _email model factories.
        /// </summary>
        private readonly IEmailModelFactories _emailModelFactories;

        /// <summary>
        /// The _email sender.
        /// </summary>
        private readonly IEmailSender _emailSender;

        /// <summary>
        /// Initializes a new instance of the <see cref="SendEmailConfirmationWhenRegistrationDoneDomainEventHandler"/> class.
        /// </summary>
        /// <param name="emailModelFactories">
        /// The email model factories.
        /// </param>
        /// <param name="emailSender">
        /// The email sender.
        /// </param>
        public SendEmailConfirmationWhenRegistrationDoneDomainEventHandler(IEmailModelFactories emailModelFactories, IEmailSender emailSender)
        {
            this._emailModelFactories = emailModelFactories;
            this._emailSender = emailSender;
        }

        /// <summary>
        /// The handle.
        /// </summary>
        /// <param name="notification">
        /// The notification.
        /// </param>
        /// <param name="cancellationToken">
        /// The cancellation token.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task Handle(RegistrationDoneDomainEvent notification, CancellationToken cancellationToken)
        {
            return Task.Run(
                () =>
                    {
                        Debug.WriteLine("event fired");
                        var emailAccount = this._emailModelFactories.PrepareEmailAccountModel();

                        this._emailSender.SendEmail(
                            emailAccount.EmailAccount,
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
