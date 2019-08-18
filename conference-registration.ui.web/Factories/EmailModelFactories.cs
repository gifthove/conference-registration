using AutoMapper;
using conference_registration.core.Entities;
using conference_registration.ui.web.Configuration;
using conference_registration.ui.web.Models;
using EmailConfiguration = conference_registration.ui.web.Configuration.EmailConfiguration;

namespace conference_registration.ui.web.Factories
{
    public class EmailModelFactories : IEmailModelFactories
    {
        public readonly IEmailConfiguration _emailConfiguration;

        private readonly IMapper _mapper;

        public EmailModelFactories(IEmailConfiguration emailConfiguration, IMapper mapper)
        {
            _emailConfiguration = emailConfiguration;
            _mapper = mapper;
        }
        public DefaultEmailModel PrepareEmailAccountModel()
        {
            EmailConfiguration emailConfiguration = _emailConfiguration as EmailConfiguration;
            var emailAccount = _mapper.Map<EmailAccount>(emailConfiguration);
            return new DefaultEmailModel() { EmailAccount = emailAccount };
        }
    }
}
