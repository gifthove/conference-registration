// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConferenceContext.cs" company="Gift Ltd">
//   © Copyright 2019 - All rights reserved
// </copyright>
// <summary>
//   Defines the ConferenceContext type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace conference_registration.data
{
    using conference_registration.core.Entities;
    using conference_registration.core.Entities.ConferenceAggregate;
    using conference_registration.core.Entities.RegistrationAggregate;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// The conference context.
    /// </summary>
    public class ConferenceContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConferenceContext"/> class.
        /// </summary>
        /// <param name="options">
        /// The options.
        /// </param>
        public ConferenceContext(DbContextOptions<ConferenceContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the attendees.
        /// </summary>
        public DbSet<Attendee> Attendees { get; set; }

        /// <summary>
        /// Gets or sets the conferences.
        /// </summary>
        public DbSet<Conference> Conferences { get; set; }

        /// <summary>
        /// Gets or sets the conference sessions.
        /// </summary>
        public DbSet<Session> Sessions { get; set; }

        /// <summary>
        /// Gets or sets the registrations.
        /// </summary>
        public DbSet<Registration> Registrations { get; set; }

        /// <summary>
        /// Gets or sets the attendee session registration.
        /// </summary>
        public DbSet<AttendeeSessionRegistration> AttendeeSessionRegistrations { get; set; }

        /// <summary>
        /// The on model creating.
        /// </summary>
        /// <param name="builder">
        /// The builder.
        /// </param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Conference>(this.ConfigureConference);
            builder.Entity<Registration>(this.ConfigureRegistration);
        }



        /// <summary>
        /// The configure conference.
        /// </summary>
        /// <param name="builder">
        /// The builder.
        /// </param>
        private void ConfigureConference(EntityTypeBuilder<Conference> builder)
        {
            var navigation = builder.Metadata.FindNavigation(nameof(Conference.Sessions));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(p => p.Name).HasMaxLength(400).IsRequired();
        }

        /// <summary>
        /// The configure registration.
        /// </summary>
        /// <param name="builder">
        /// The builder.
        /// </param>
        private void ConfigureRegistration(EntityTypeBuilder<Registration> builder)
        {
            var navigation = builder.Metadata.FindNavigation(nameof(Registration.AttendingSessions));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        /// <summary>
        /// The configure attendee.
        /// </summary>
        /// <param name="builder">
        /// The builder.
        /// </param>
        private void ConfigureAttendee(EntityTypeBuilder<Attendee> builder)
        {
            builder.Property(p => p.Title).HasMaxLength(4).IsRequired();
            builder.Property(p => p.FirstName).HasMaxLength(400).IsRequired();
            builder.Property(p => p.LastName).HasMaxLength(400).IsRequired();
        }

    }
}
