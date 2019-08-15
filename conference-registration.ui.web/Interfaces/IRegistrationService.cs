// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRegistrationService.cs" company="Gift Ltd">
//   © Copyright 2019 - All rights reserved
// </copyright>
// <summary>
//   Defines the IRegistrationService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using conference_registration.core.Paging;

namespace conference_registration.ui.web.Interfaces
{
    using System.Collections.Generic;

    using conference_registration.core.Entities.RegistrationAggregate;
    using conference_registration.ui.web.Models;
    using conference_registration.ui.web.ViewModel;

    /// <summary>
    /// The RegistrationService interface.
    /// </summary>
    public interface IRegistrationService
    {
        /// <summary>
        /// The get registration by id.
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
        /// The get paged registrations.
        /// </summary>
        /// <param name="searchModel"></param>
        /// <returns>
        /// The <see cref="PagedList{T}"/>.
        /// </returns>
        PagedList<RegistrationViewModel> GetPagedRegistrations(SearchModel searchModel);

        /// <summary>
        /// The create registration.
        /// </summary>
        /// <param name="registrationViewModel">
        /// The registration view model.
        /// </param>
        void CreateRegistration(RegistrationViewModel registrationViewModel);

        /// <summary>
        /// The update registration.
        /// </summary>
        /// <param name="registrationViewModel">
        /// The registration view model.
        /// </param>
        void UpdateRegistration(RegistrationViewModel registrationViewModel);

        /// <summary>
        /// The delete registration.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        void DeleteRegistration(int id);
    }
}
