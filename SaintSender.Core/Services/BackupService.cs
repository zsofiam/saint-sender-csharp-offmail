using SaintSender.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows;

namespace SaintSender.Core.Services
{
    public class BackupService : IBackupService
    {
        public bool SaveBackup(string address, IList<EmailInfo> emails)
        {
            DeleteBackup(address);

            // Save as the first part of the email address: for example: hello.hello.hello.howlow@gmail.com becomes hello.hello.hello.howlow (nirvana rocks!)
            using (StreamWriter writer = File.CreateText(address.Split('@')[0]+".backup"))
            {
                try
                {
                string jsonString = JsonConvert.SerializeObject(emails);

                    writer.Write(jsonString);

                    writer.Close();

                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public IList<EmailInfo> LoadEmails(string address, int from, int to)
        {
            IList<EmailInfo> emails;
            IList<EmailInfo> filteredEmails = new List<EmailInfo>();

            using (StreamReader reader = new StreamReader(address.Split('@')[0] + ".backup"))
            {
                try
                {
                    string jsonString = reader.ReadToEnd();

                    emails = JsonConvert.DeserializeObject<IList<EmailInfo>>(jsonString);
                }
                catch
                {
                    return null;
                }
            }

            // only get from - to
            for (int i = 0; i < emails.Count(); i++)
            {
                if ((i + 1) >= from && (i + 1) <= to) filteredEmails.Add(emails[i]);
            }
            return filteredEmails;
        }

        public IList<EmailInfo> SearchEmails(string address, string searchTerm)
        {
            IList<EmailInfo> emails;
            IList<EmailInfo> filteredEmails = new List<EmailInfo>();

            using (StreamReader reader = new StreamReader(address.Split('@')[0] + ".backup"))
            {
                try
                {
                    string jsonString = reader.ReadToEnd();

                    emails = JsonConvert.DeserializeObject<IList<EmailInfo>>(jsonString);
                }
                catch
                {
                    return null;
                }
            }

            for (int i = 0; i < emails.Count(); i++)
            {
                if ((emails[i].Subject != null && emails[i].Subject.Contains(searchTerm)) || (emails[i].Body != null && emails[i].Body.Contains(searchTerm)) || (emails[i].Sender != null && emails[i].Sender.Contains(searchTerm))) filteredEmails.Add(emails[i]);
            }
            return filteredEmails;
        }

        public void DeleteBackup(string address)
        {
            if (File.Exists(address.Split('@')[0] + ".backup")) File.Delete(address.Split('@')[0] + ".backup");
        }

        public bool BackupExitsts(string address)
        {
            return (File.Exists(address.Split('@')[0] + ".backup"));
        }
    }
}
