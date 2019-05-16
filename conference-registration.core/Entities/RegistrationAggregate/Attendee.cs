// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Attendee.cs" company="Gift Ltd">
//   © Copyright 2019 - All rights reserved
// </copyright>
// <summary>
//   Defines the Attendee type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace conference_registration.core.Entities.RegistrationAggregate
{
    using conference_registration.core.Interfaces;

    /// <summary>
    /// The attendee.
    /// </summary>
    public class Attendee : BaseEntity
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// Gets or sets the address line 1.
        /// </summary>
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Gets or sets the address line 2.
        /// </summary>
        public string AddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the postal code.
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets the fax.
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// Gets or sets the company.
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// Gets or sets the workphone.
        /// </summary>
        public string Workphone { get; set; }

        /// <summary>
        /// Gets or sets the mobile phone.
        /// </summary>
        public string MobilePhone { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether terms and conditions.
        /// </summary>
        public bool TermsAndConditions { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether individual booking.
        /// </summary>
        public bool IndividualBooking { get; set; }

    }
}
