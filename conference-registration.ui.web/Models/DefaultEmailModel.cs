using System.Collections.Generic;
using conference_registration.core.Entities;

namespace conference_registration.ui.web.Models
{
    public class DefaultEmailModel
    {
        public EmailAccount EmailAccount { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string FromAddress { get; set; }
        public string FromName { get; set; }
        public string ToAddress { get; set; }
        public string ToName { get; set; }
        public string ReplyToAddress { get; set; }
        public string ReplyToName { get; set; }
        public IEnumerable<string> Bcc { get; set; }
        public IEnumerable<string> Cc { get; set; }
        public string AttachmentFilePath { get; set; }
        public string AttachmentFileName { get; set; }
        public int AttachedDownloadId { get; set; }
        public IDictionary<string, string> Headers { get; set; }
    }
}
