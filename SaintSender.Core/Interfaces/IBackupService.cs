using SaintSender.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintSender.Core.Interfaces
{
    public interface IBackupService
    {
        void SaveBackup(string address, IList<EmailInfo> emails);

        IList<EmailInfo> LoadEmails(string address);

        void DeleteBackup(string address);
    }
}
