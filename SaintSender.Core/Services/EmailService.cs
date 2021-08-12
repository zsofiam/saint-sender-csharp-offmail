using SaintSender.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Imap;
using MailKit.Security;
using MailKit;
using System.Windows;
using MailKit.Search;
using MimeKit;
using MimeKit.Text;

namespace SaintSender.Core.Services
{
    public class EmailService : IEmailService
    {
        public IList<EmailInfo> GetEmails(string address, string password, int from, int to)
        {
            IList<EmailInfo> emails = new List<EmailInfo>();

            using (var client = new ImapClient())
            {
                try
                {
                    client.Connect("imap.gmail.com", 993, SecureSocketOptions.SslOnConnect);
                    client.Authenticate(address, password);

                    client.Inbox.Open(MailKit.FolderAccess.ReadOnly);

                    var items = client.Inbox.Fetch(from, to, MessageSummaryItems.UniqueId | MessageSummaryItems.BodyStructure);

                    foreach (var item in items)
                    {
                        var message = client.Inbox.GetMessage(item.UniqueId);

                        EmailInfo emailInfo = new EmailInfo(message.From.ToString(), message.Date.DateTime, message.Subject, message.TextBody, false);
                        emails.Add(emailInfo);
                    }

                    client.Disconnect(true);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong: " + e.ToString(), "There was an issue..", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                return emails;
            }
        }

        public IList<EmailInfo> GetEmails(string address, string password, string searchTerm)
        {
            IList<EmailInfo> emails = new List<EmailInfo>();

            using (var client = new ImapClient())
            {
                try
                {
                    client.Connect("imap.gmail.com", 993, SecureSocketOptions.SslOnConnect);
                    client.Authenticate(address, password);

                    client.Inbox.Open(MailKit.FolderAccess.ReadOnly);

                    var query = SearchQuery.SubjectContains(searchTerm).Or(SearchQuery.SubjectContains(searchTerm));
                    var uids = client.Inbox.Search(query);

                    var items = client.Inbox.Fetch(uids, MessageSummaryItems.UniqueId | MessageSummaryItems.BodyStructure);

                    foreach (var item in items)
                    {
                        var message = client.Inbox.GetMessage(item.UniqueId);

                        EmailInfo emailInfo = new EmailInfo(message.From.ToString(), message.Date.DateTime, message.Subject, message.TextBody, false);
                        emails.Add(emailInfo);
                    }

                    client.Disconnect(true);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong: " + e.ToString(), "There was an issue..", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                return emails;
            }
        }

        public bool SendEmail(string address, string password, string from, string to, string cc, string subject, string body)
        {
            var messageToSend = new MimeMessage
            {
                Sender = new MailboxAddress(from, from),
                Subject = subject,
            };

            messageToSend.Body = new TextPart(TextFormat.Plain) { Text = body };
            messageToSend.To.Add(new MailboxAddress(to, to));
            if (cc != string.Empty) messageToSend.Cc.Add(new MailboxAddress(cc, cc));

            try
            {
                using (var smtp = new MailKit.Net.Smtp.SmtpClient())
                {
                    smtp.MessageSent += (sender, args) => { };
                    smtp.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    smtp.Connect("smtp.gmail.com", 465, SecureSocketOptions.SslOnConnect);

                    smtp.Authenticate(address, password);
                    smtp.Send(messageToSend);
                    smtp.Disconnect(true);

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
