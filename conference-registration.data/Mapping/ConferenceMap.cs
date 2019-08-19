// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConferenceMap.cs" company="Gift Ltd">
//   © Copyright 2019 - All rights reserved
// </copyright>
// <summary>
//   Defines the ConferenceMap type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace conference_registration.data.Mapping
{
    using conference_registration.core.Entities.ConferenceAggregate;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// The conference map.
    /// </summary>
    public class ConferenceMap : ConferenceContextConfiguration<Conference>
    {
        /// <summary>
        /// The configure.
        /// </summary>
        /// <param name="builder">
        /// The builder.
        /// </param>
        public override void Configure(EntityTypeBuilder<Conference> builder)
        {
            builder.ToTable("Conferences");
            var navigation = builder.Metadata.FindNavigation(nameof(Conference.Sessions));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(p => p.Name).HasMaxLength(400).IsRequired();

            // add custom configuration
            this.PostConfigure(builder);
        }
    }
}
