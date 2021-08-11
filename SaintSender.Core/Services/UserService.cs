using SaintSender.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit;
using MailKit.Net.Smtp;
using System.Net;
using System.Threading;
using System.Windows;
using System.IO;
using System.IO.IsolatedStorage;

namespace SaintSender.Core.Services
{
    public class UserService : IUserService
    {
        private const string AUTO_LOGIN_FILE = "autologin.cfg";

        private bool LoggedIn = false;

        // Check if the email address we used is valid
        public bool IsValidEmail(string address)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(address);
                return addr.Address == address;
            }
            catch
            {
                return false;
            }
        }

        // Check if the credentials are correct or not
        public bool CanAuthenticate(string address, string password)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect("smtp.gmail.com", 465, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH");
                    client.Authenticate(address, password);
                    client.Disconnect(true);

                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        // If the user checks auto login, save the credentials
        public void SaveCredentials(string address, string password)
        {
            IsolatedStorageFile store = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);

            using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(AUTO_LOGIN_FILE, FileMode.Create, store))
            using (StreamWriter writer = new StreamWriter(stream))
            {
                writer.WriteLine(address);
                // HEADS UP: YOU SHOULD HASH THIS
                writer.WriteLine(password);
            }
        }

        // Check if the auto login file exists and we can login back
        public bool AutoLogin()
        {
            string address = string.Empty;
            string password = string.Empty;

            IsolatedStorageFile store = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);

            try
            {
                using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(AUTO_LOGIN_FILE, FileMode.Create, store))
                using (StreamReader reader = new StreamReader(stream))
                {
                    address = reader.ReadLine();
                    // HEADS UP: YOU SHOULD HASH THIS
                    password = reader.ReadLine();
                }
            }
            catch
            {
                return false;
            }

            if (CanAuthenticate(address, password)) return true;
            else return false;
        }

        public bool IsLoggedIn()
        {
            return LoggedIn;
        }

        public void SetLoggedIn(bool log)
        {
            LoggedIn = log;
        }
    }
}