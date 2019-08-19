// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEmailConfiguration.cs" company="Gift Ltd">
//   © Copyright 2019 - All rights reserved
// </copyright>
// <summary>
//   The EmailConfiguration interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace conference_registration.ui.web.Configuration
{
    /// <summary>
    /// The EmailConfiguration interface.
    /// </summary>
    public interface IEmailConfiguration
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Gets or sets an email address
        /// </summary>
        string Email { get; set; }

        /// <summary>
        /// Gets or sets an email display name
        /// </summary>
        string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets an email host
        /// </summary>
        string Host { get; set; }

        /// <summary>
        /// Gets or sets an email port
        /// </summary>
        int Port { get; set; }

        /// <summary>
        /// Gets or sets an email user name
        /// </summary>
        string Username { get; set; }

        /// <summary>
        /// Gets or sets an email password
        /// </summary>
        string Password { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether that controls whether the SmtpClient uses Secure Sockets Layer (SSL) to encrypt the connection
        /// </summary>
        bool EnableSsl { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether that controls whether the default system credentials of the application are sent with requests.
        /// </summary>
        bool UseDefaultCredentials { get; set; }
    }
}