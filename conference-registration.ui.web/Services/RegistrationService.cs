// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegistrationService.cs" company="Gift Ltd">
//   © Copyright 2019 - All rights reserved
// </copyright>
// <summary>
//   The registration service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace conference_registration.ui.web.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using conference_registration.common;
    using conference_registration.core.Entities.RegistrationAggregate;
    using conference_registration.core.Interfaces;
    using conference_registration.ui.web.Interfaces;
    using conference_registration.ui.web.ViewModel;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The registration service.
    /// </summary>
    public class RegistrationService : IRegistrationService
    {
        /// <summary>
        /// The _logger.
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// The _mapper.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// The _registration repository.
        /// </summary>
        private readonly IRepository<Registration> _registrationRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegistrationService"/> class.
        /// </summary>
        /// <param name="registrationRepository">
        /// The registration repository.
        /// </param>
        /// <param name="logger">
        /// The logger.
        /// </param>
        /// <param name="mapper">
        /// The mapper.
        /// </param>
        public RegistrationService(IRepository<Registration> registrationRepository, ILogger<RegistrationService> logger, IMapper mapper)
        {
            this._registrationRepository = registrationRepository;
            this._logger = logger;
            this._mapper = mapper;
        }

        /// <summary>
        /// The get registration by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Registration"/>.
        /// </returns>
        public Registration GetRegistrationById(int id)
        {
            this._logger.LogInformation(LoggingEvents.GetItem, "Getting item {ID}", id);
            var registration = this._registrationRepository.GetById(id);
            if (registration != null) return registration;
            this._logger.LogWarning(LoggingEvents.GetItemNotFound, "GetRegistrationById({ID}) NOT FOUND", id);
            return null;
        }

        /// <summary>
        /// The get all registrations.
        /// </summary>
        /// <returns>
        /// The <see>
        ///         <cref>List</cref>
        ///     </see>
        ///     .
        /// </returns>
        public List<RegistrationViewModel> GetAllRegistrations()
        {
            this._logger.LogInformation(LoggingEvents.ListItems, "Get all registrations");
            var registrations = this._registrationRepository.List().ToList();
            return this._mapper.Map<List<RegistrationViewModel>>(registrations);
        }

        /// <summary>
        /// The create registration.
        /// </summary>
        /// <param name="registrationViewModel">
        /// The registration View Model.
        /// </param>
        public void CreateRegistration(RegistrationViewModel registrationViewModel)
        {
            this._logger.LogInformation(LoggingEvents.InsertItem, "Create Registration");
            var registration = this._mapper.Map<Registration>(registrationViewModel);
            registration.AddAttendeeSessionRegistration(registrationViewModel.AttendingSessions.ToList());
            this._registrationRepository.Insert(registration);
        }

        /// <summary>
        /// The update registration.
        /// </summary>
        /// <param name="registrationViewModel">
        /// The registration View Model.
        /// </param>
        public void UpdateRegistration(RegistrationViewModel registrationViewModel)
        {
            this._logger.LogInformation(LoggingEvents.UpdateItem, "Update Registration");
            var registration = this._mapper.Map<Registration>(registrationViewModel);
            registration.AddAttendeeSessionRegistration(registrationViewModel.AttendingSessions.ToList());
            this._registrationRepository.Update(registration);
        }

        /// <summary>
        /// The delete registration.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public void DeleteRegistration(int id)
        {
            this._logger.LogInformation(LoggingEvents.DeleteItem, "Delete Registration");
            this._registrationRepository.Delete(id);
        }
    }
}
