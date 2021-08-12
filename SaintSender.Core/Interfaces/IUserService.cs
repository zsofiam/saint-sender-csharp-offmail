using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintSender.Core.Interfaces
{
    public interface IUserService
    {
        bool IsValidEmail(string address);
        bool CanAuthenticate(string address, string password);
        void SaveCredentials(string address, string password);
        bool AutoLogin();
        void SaveSession(string address, string password);
        string GetSessionAddress();
        string GetSessionPassword();
        void DeleteSession();
        bool IsLoggedIn();
        void SetLoggedIn(bool log);
        void DeleteCredentials();
    }
}
