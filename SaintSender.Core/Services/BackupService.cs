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

        public IList<EmailInfo> LoadEmails(string address)
        {
            IList<EmailInfo> emails;

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

            return emails;
        }

        public void DeleteBackup(string address)
        {
            if (File.Exists(address.Split('@')[0] + ".backup")) File.Delete(address.Split('@')[0] + ".backup");
        }
    }
}
