using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace conference_registration.ui.web.Configuration
{
    public class EmailConfiguration : IEmailConfiguration
    {
        public int Id { get; set; }
        public string Email { get; set; }

        public string DisplayName { get; set; }

        public string Host { get; set; }

        public int Port { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public bool EnableSsl { get; set; }

        public bool UseDefaultCredentials { get; set; }

    }

    public interface IEmailConfiguration
    {
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
        /// Gets or sets a value that controls whether the SmtpClient uses Secure Sockets Layer (SSL) to encrypt the connection
        /// </summary>
         bool EnableSsl { get; set; }

        /// <summary>
        /// Gets or sets a value that controls whether the default system credentials of the application are sent with requests.
        /// </summary>
         bool UseDefaultCredentials { get; set; }
    }
}
