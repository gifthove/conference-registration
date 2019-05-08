// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DbInitializer.cs" company="Gift Ltd">
//   © Copyright 2019 - All rights reserved
// </copyright>
// <summary>
//   Defines the DbInitializer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace conference_registration.data
{
    using conference_registration.core.Entities.RegistrationAggregate;

    using Microsoft.EntityFrameworkCore.Internal;

    /// <summary>
    /// The db initializer.
    /// </summary>
    public static class DbInitializer
    {
        /// <summary>
        /// The initialize.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public static void Initialize(ConferenceContext context)
        {
            context.Database.EnsureCreated();

            // Look for any attendees.
            if (context.Attendees.Any())
            {
                return;   // DB has been seeded
            }

            var attendees = new[]
                                {
                                    new Attendee { FirstName = "Carson", LastName = "Alexander", Title = "Mr" },
                                    new Attendee { FirstName = "Meredith", LastName = "Alonso", Title = "Mr" },
                                    new Attendee { FirstName = "Arturo", LastName = "Anand", Title = "Mr" },
                                    new Attendee { FirstName = "Gytis", LastName = "Barzdukas", Title = "Mr" },
                                    new Attendee { FirstName = "Yan", LastName = "Li", Title = "Mr" },
                                    new Attendee { FirstName = "Peggy", LastName = "Justice", Title = "Mr" },
                                    new Attendee { FirstName = "Laura", LastName = "Norman", Title = "Mr" },
                                    new Attendee { FirstName = "Nino", LastName = "Olivetto", Title = "Mr" }
                                };

            foreach (var a in attendees)
            {
                context.Attendees.Add(a);
            }

            context.SaveChanges();
        }
    }
}
