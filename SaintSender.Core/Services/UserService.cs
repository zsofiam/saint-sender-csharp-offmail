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

namespace SaintSender.Core.Services
{
    public class UserService : IUserService
    {
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

        public bool canAuthenticate(string address, string password)
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
    }
}
