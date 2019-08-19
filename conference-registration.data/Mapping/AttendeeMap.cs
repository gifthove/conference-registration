// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AttendeeMap.cs" company="Gift Ltd">
//   © Copyright 2019 - All rights reserved
// </copyright>
// <summary>
//   Defines the AttendeeMap type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace conference_registration.data.Mapping
{
    using conference_registration.core.Entities.RegistrationAggregate;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// The attendee map.
    /// </summary>
    public class AttendeeMap : ConferenceContextConfiguration<Attendee>
    {
        /// <summary>
        /// The configure.
        /// </summary>
        /// <param name="builder">
        /// The builder.
        /// </param>
        public override void Configure(EntityTypeBuilder<Attendee> builder)
        {
            builder.ToTable("Attendees");
            builder.Property(p => p.Title).HasMaxLength(4).IsRequired();
            builder.Property(p => p.FirstName).HasMaxLength(400).IsRequired();
            builder.Property(p => p.LastName).HasMaxLength(400).IsRequired();

            // add custom configuration
            this.PostConfigure(builder);
        }
    }
}
