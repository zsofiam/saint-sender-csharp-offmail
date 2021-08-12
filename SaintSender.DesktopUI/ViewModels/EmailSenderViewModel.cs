using SaintSender.Core.Interfaces;
using SaintSender.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintSender.DesktopUI.ViewModels
{
    class EmailSenderViewModel
    {
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;

        public EmailSenderViewModel()
        {
            _userService = new UserService();
            _emailService = new EmailService();
        }

        public bool IsValidEmail(string address)
        {
            return _userService.IsValidEmail(address);
        }

        public bool SendEmail(string to, string cc, string subject, string body)
        {
            return _emailService.SendEmail(_userService.GetSessionAddress(), _userService.GetSessionPassword(), _userService.GetSessionAddress(), to, cc, subject, body);
        }
    }
}
