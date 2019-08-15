using System;
using System.Collections.Generic;
using System.Text;
using conference_registration.core.Entities.RegistrationAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace conference_registration.data.Mapping
{
    public class AttendeeMap : ConferenceContextConfiguration<Attendee>
    {

        public override void Configure(EntityTypeBuilder<Attendee> builder)
        {
            builder.ToTable("Attendees");
            builder.Property(p => p.Title).HasMaxLength(4).IsRequired();
            builder.Property(p => p.FirstName).HasMaxLength(400).IsRequired();
            builder.Property(p => p.LastName).HasMaxLength(400).IsRequired();

            //add custom configuration
            this.PostConfigure(builder);
        }
    }
}
