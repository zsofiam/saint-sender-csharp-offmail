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
        private IUserService _userService;

        public EmailSenderViewModel()
        {
            _userService = new UserService();
        }

        public bool IsValidEmail(string address)
        {
            return _userService.IsValidEmail(address);
        }
    }
}
