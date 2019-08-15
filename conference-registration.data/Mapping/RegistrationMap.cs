using System;
using System.Collections.Generic;
using System.Text;
using conference_registration.core.Entities.RegistrationAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace conference_registration.data.Mapping
{
    public class RegistrationMap: ConferenceContextConfiguration<Registration>
    {

        public override void Configure(EntityTypeBuilder<Registration> builder)
        {
            builder.ToTable("Registrations");
            var navigation = builder.Metadata.FindNavigation(nameof(Registration.AttendingSessions));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            //add custom configuration
            this.PostConfigure(builder);
        }
    }
}
