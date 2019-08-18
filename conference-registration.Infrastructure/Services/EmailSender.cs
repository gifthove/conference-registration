using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using conference_registration.core.Entities;
using conference_registration.core.Interfaces;

namespace conference_registration.Infrastructure.Services
{
    public class EmailSender : IEmailSender
    {
        public void SendEmail(EmailAccount emailAccount, string subject, string body,
            string fromAddress, string fromName, string toAddress, string toName,
            string replyTo = null, string replyToName = null,
            IEnumerable<string> bcc = null, IEnumerable<string> cc = null,
            string attachmentFilePath = null, string attachmentFileName = null,
            int attachedDownloadId = 0, IDictionary<string, string> headers = null)
        {
            var message = PrepareMailMessage(subject, body, fromAddress, fromName, toAddress, toName, replyTo, replyToName, bcc, cc, headers);

            //send email
            using (var smtpClient = new SmtpClient())
            {
                PrepareSmtpClient(emailAccount, smtpClient);
                smtpClient.Send(message);
            }
        }

        public Task SendEmailAsync(EmailAccount emailAccount, string subject, string body,
            string fromAddress, string fromName, string toAddress, string toName,
            string replyTo = null, string replyToName = null,
            IEnumerable<string> bcc = null, IEnumerable<string> cc = null,
            string attachmentFilePath = null, string attachmentFileName = null,
            int attachedDownloadId = 0, IDictionary<string, string> headers = null)
        {
            Task result;
            var message = PrepareMailMessage(subject, body, fromAddress, fromName, toAddress, toName, replyTo, replyToName, bcc, cc, headers);

            //send email
            using (var smtpClient = new SmtpClient())
            {
                PrepareSmtpClient(emailAccount, smtpClient);
                result = smtpClient.SendMailAsync(message);
            }

            return result;
        }

        private  void PrepareSmtpClient(EmailAccount emailAccount, SmtpClient smtpClient)
        {
            smtpClient.UseDefaultCredentials = emailAccount.UseDefaultCredentials;
            smtpClient.Host = emailAccount.Host;
            smtpClient.Port = emailAccount.Port;
            smtpClient.EnableSsl = emailAccount.EnableSsl;
            smtpClient.Credentials = emailAccount.UseDefaultCredentials
                ? CredentialCache.DefaultNetworkCredentials
                : new NetworkCredential(emailAccount.Username, emailAccount.Password);
        }

        private MailMessage PrepareMailMessage(string subject, string body, string fromAddress, string fromName,
            string toAddress, string toName, string replyTo, string replyToName, IEnumerable<string> bcc, IEnumerable<string> cc,
            IDictionary<string, string> headers)
        {
            var message = new MailMessage
            {
                //from, to, reply to
                From = new MailAddress(fromAddress, fromName)
            };
            message.To.Add(new MailAddress(toAddress, toName));
            if (!string.IsNullOrEmpty(replyTo))
            {
                message.ReplyToList.Add(new MailAddress(replyTo, replyToName));
            }

            //BCC
            if (bcc != null)
            {
                foreach (var address in bcc.Where(bccValue => !string.IsNullOrWhiteSpace(bccValue)))
                {
                    message.Bcc.Add(address.Trim());
                }
            }

            //CC
            if (cc != null)
            {
                foreach (var address in cc.Where(ccValue => !string.IsNullOrWhiteSpace(ccValue)))
                {
                    message.CC.Add(address.Trim());
                }
            }

            //content
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;

            //headers
            if (headers != null)
                foreach (var header in headers)
                {
                    message.Headers.Add(header.Key, header.Value);
                }

            return message;
        }
    }
}
