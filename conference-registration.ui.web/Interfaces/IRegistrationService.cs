// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRegistrationService.cs" company="Gift Ltd">
//   © Copyright 2019 - All rights reserved
// </copyright>
// <summary>
//   Defines the IRegistrationService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace conference_registration.ui.web.Interfaces
{
    using System.Collections.Generic;

    using conference_registration.core.Entities.RegistrationAggregate;
    using conference_registration.ui.web.ViewModel;

    /// <summary>
    /// The RegistrationService interface.
    /// </summary>
    public interface IRegistrationService
    {
        /// <summary>
        /// The get attendee by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Registration"/>.
        /// </returns>
        Registration GetRegistrationById(int id);

        /// <summary>
        /// The get all registrations.
        /// </summary>
        /// <returns>
        /// The <see>
        ///         <cref>List</cref>
        ///     </see>
        ///     .
        /// </returns>
        List<RegistrationViewModel> GetAllRegistrations();

        /// <summary>
        /// The create attendee.
        /// </summary>
        /// <param name="attendee">
        /// The attendee.
        /// </param>
        void CreateRegistration(RegistrationViewModel attendee);

        /// <summary>
        /// The update attendee.
        /// </summary>
        /// <param name="attendee">
        /// The attendee.
        /// </param>
        void UpdateRegistration(Registration attendee);

        /// <summary>
        /// The delete attendee.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        void DeleteRegistration(int id);
    }
}
