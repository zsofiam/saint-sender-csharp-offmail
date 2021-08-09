using SaintSender.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public bool canAuthenticate(string address, string email)
        {
            throw new NotImplementedException();
        }
    }
}
