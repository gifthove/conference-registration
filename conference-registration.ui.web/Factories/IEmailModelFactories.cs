// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEmailModelFactories.cs" company="Gift Ltd">
//   © Copyright 2019 - All rights reserved
// </copyright>
// <summary>
//   Defines the IEmailModelFactories type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace conference_registration.ui.web.Factories
{
    using conference_registration.ui.web.Models;

    /// <summary>
    /// The EmailModelFactories interface.
    /// </summary>
    public interface IEmailModelFactories
    {
        /// <summary>
        /// The prepare email account model.
        /// </summary>
        /// <returns>
        /// The <see cref="DefaultEmailModel"/>.
        /// </returns>
        DefaultEmailModel PrepareEmailAccountModel();
    }
}