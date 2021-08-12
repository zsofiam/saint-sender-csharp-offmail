using SaintSender.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintSender.Core.Interfaces
{
    public interface IEmailService
    {
        IList<EmailInfo> GetEmails(string address, string password, int from, int to);
        IList<EmailInfo> GetEmails(string address, string password, string searchTerm);
        bool SendEmail(string address, string password, string from, string to, string cc, string subject, string body);
    }
}
