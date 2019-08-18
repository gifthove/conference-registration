// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MappingProfile.cs" company="Gift Ltd">
//   © Copyright 2019 - All rights reserved
// </copyright>
// <summary>
//   Defines the MappingProfileMappingProfile type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using conference_registration.core.Entities;
using conference_registration.ui.web.Configuration;
using conference_registration.ui.web.Factories;

namespace conference_registration.ui.web.MapperProfiles
{
    using AutoMapper;

    using core.Entities.RegistrationAggregate;
    using ViewModel;

    /// <summary>
    /// The mapping profile mapping profile.
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfile"/> class.
        /// </summary>
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            this.CreateMap<Registration, RegistrationViewModel>().ReverseMap();
            this.CreateMap<EmailAccount, EmailModelFactories>().ReverseMap();
        }
    }
}
