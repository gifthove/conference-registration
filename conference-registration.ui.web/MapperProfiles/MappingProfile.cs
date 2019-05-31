// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MappingProfile.cs" company="Gift Ltd">
//   © Copyright 2019 - All rights reserved
// </copyright>
// <summary>
//   Defines the MappingProfileMappingProfile type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace conference_registration.ui.web.MapperProfiles
{
    using AutoMapper;

    using conference_registration.core.Entities.RegistrationAggregate;
    using conference_registration.ui.web.ViewModel;

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
        }
    }
}
