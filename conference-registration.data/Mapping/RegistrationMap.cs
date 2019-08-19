// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegistrationMap.cs" company="Gift Ltd">
//   © Copyright 2019 - All rights reserved
// </copyright>
// <summary>
//   Defines the RegistrationMap type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace conference_registration.data.Mapping
{
    using conference_registration.core.Entities.RegistrationAggregate;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// The registration map.
    /// </summary>
    public class RegistrationMap : ConferenceContextConfiguration<Registration>
    {
        /// <summary>
        /// The configure.
        /// </summary>
        /// <param name="builder">
        /// The builder.
        /// </param>
        public override void Configure(EntityTypeBuilder<Registration> builder)
        {
            builder.ToTable("Registrations");
            var navigation = builder.Metadata.FindNavigation(nameof(Registration.AttendingSessions));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            // add custom configuration
            this.PostConfigure(builder);
        }
    }
}
