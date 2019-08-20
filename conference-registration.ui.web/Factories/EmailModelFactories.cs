// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailModelFactories.cs" company="Gift Ltd">
//   © Copyright 2019 - All rights reserved
// </copyright>
// <summary>
//   Defines the EmailModelFactories type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



namespace conference_registration.ui.web.Factories
{
    using AutoMapper;

    using conference_registration.core.Entities;
    using conference_registration.ui.web.Configuration;
    using conference_registration.ui.web.Models;

    using EmailConfiguration = conference_registration.ui.web.Configuration.EmailConfiguration;

    /// <summary>
    /// The email model factories.
    /// </summary>
    public class EmailModelFactories : IEmailModelFactories
    {
        /// <summary>
        /// The _email configuration.
        /// </summary>
        private readonly IEmailConfiguration _emailConfiguration;

        /// <summary>
        /// The _mapper.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailModelFactories"/> class.
        /// </summary>
        /// <param name="emailConfiguration">
        /// The email configuration.
        /// </param>
        /// <param name="mapper">
        /// The mapper.
        /// </param>
        public EmailModelFactories(IEmailConfiguration emailConfiguration, IMapper mapper)
        {
            this._emailConfiguration = emailConfiguration;
            this._mapper = mapper;
        }

        /// <summary>
        /// The prepare email account model.
        /// </summary>
        /// <returns>
        /// The <see cref="DefaultEmailModel"/>.
        /// </returns>
        public DefaultEmailModel PrepareEmailAccountModel()
        {
            EmailConfiguration emailConfiguration = this._emailConfiguration as EmailConfiguration;
            var emailAccount = this._mapper.Map<EmailAccount>(emailConfiguration);
            return new DefaultEmailModel() { EmailAccount = emailAccount };
        }
    }
}
