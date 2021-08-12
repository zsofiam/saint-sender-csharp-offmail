using SaintSender.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintSender.Core.Services
{
    public class BackupService : IBackupService
    {
        public void SaveBackup(string address, IList<EmailInfo> emails)
        {
            throw new NotImplementedException();
        }

        public IList<EmailInfo> LoadEmails(string address)
        {
            throw new NotImplementedException();
        }

        public void DeleteBackup(string address)
        {
            throw new NotImplementedException();
        }
    }
}
