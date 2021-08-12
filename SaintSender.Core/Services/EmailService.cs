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
    }
}
