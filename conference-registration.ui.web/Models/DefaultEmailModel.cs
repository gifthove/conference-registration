// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultEmailModel.cs" company="Gift Ltd">
//   © Copyright 2019 - All rights reserved
// </copyright>
// <summary>
//   Defines the DefaultEmailModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace conference_registration.ui.web.Models
{
    using System.Collections.Generic;

    using conference_registration.core.Entities;

    /// <summary>
    /// The default email model.
    /// </summary>
    public class DefaultEmailModel
    {
        /// <summary>
        /// Gets or sets the email account.
        /// </summary>
        public EmailAccount EmailAccount { get; set; }

        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets the from address.
        /// </summary>
        public string FromAddress { get; set; }

        /// <summary>
        /// Gets or sets the from name.
        /// </summary>
        public string FromName { get; set; }

        /// <summary>
        /// Gets or sets the to address.
        /// </summary>
        public string ToAddress { get; set; }

        /// <summary>
        /// Gets or sets the to name.
        /// </summary>
        public string ToName { get; set; }

        /// <summary>
        /// Gets or sets the reply to address.
        /// </summary>
        public string ReplyToAddress { get; set; }

        /// <summary>
        /// Gets or sets the reply to name.
        /// </summary>
        public string ReplyToName { get; set; }

        /// <summary>
        /// Gets or sets the bcc.
        /// </summary>
        public IEnumerable<string> Bcc { get; set; }

        /// <summary>
        /// Gets or sets the cc.
        /// </summary>
        public IEnumerable<string> Cc { get; set; }

        /// <summary>
        /// Gets or sets the attachment file path.
        /// </summary>
        public string AttachmentFilePath { get; set; }

        /// <summary>
        /// Gets or sets the attachment file name.
        /// </summary>
        public string AttachmentFileName { get; set; }

        /// <summary>
        /// Gets or sets the attached download id.
        /// </summary>
        public int AttachedDownloadId { get; set; }

        /// <summary>
        /// Gets or sets the headers.
        /// </summary>
        public IDictionary<string, string> Headers { get; set; }
    }
}
