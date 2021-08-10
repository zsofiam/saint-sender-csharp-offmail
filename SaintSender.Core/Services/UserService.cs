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

namespace SaintSender.Core.Services
{
    public class UserService : IUserService
    {
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
        public void SaveCredentials(string address, string email)
        {

        }

        // Check if the auto login file exists and we can login back
        public bool AutoLogin()
        {
            return false;
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