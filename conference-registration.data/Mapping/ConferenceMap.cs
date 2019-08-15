using conference_registration.core.Entities.ConferenceAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace conference_registration.data.Mapping
{
    public class ConferenceMap: ConferenceContextConfiguration<Conference>
    {
        public override void Configure(EntityTypeBuilder<Conference> builder)
        {
            builder.ToTable("Conferences");
            var navigation = builder.Metadata.FindNavigation(nameof(Conference.Sessions));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(p => p.Name).HasMaxLength(400).IsRequired();

            //add custom configuration
            this.PostConfigure(builder);
        }
    }
}
