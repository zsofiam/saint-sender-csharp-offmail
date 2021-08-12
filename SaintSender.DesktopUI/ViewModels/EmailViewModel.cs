using SaintSender.Core.Interfaces;
using SaintSender.Core.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SaintSender.DesktopUI.ViewModels
{
    class EmailViewModel : INotifyPropertyChanged
    {
        private readonly EmailInfo _emailInfo;
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;


        public event PropertyChangedEventHandler PropertyChanged;

        public EmailViewModel(EmailInfo emailInfo)
        {
            _emailInfo = emailInfo;
            _userService = new UserService();
            _emailService = new EmailService();
        }

        internal void SendReply(string body)
        {
            string replyAddress = _emailInfo.Sender.Split('<')[1].Remove(_emailInfo.Sender.Split('<')[1].Length - 1);
            if (_emailService.SendEmail(_userService.GetSessionAddress(), _userService.GetSessionPassword(), _userService.GetSessionAddress(), replyAddress, "", "RE: "+_emailInfo.Subject, body))
            {
                MessageBox.Show("Message has been sent!");
            }
            else MessageBox.Show("Failed to send reply!", "Fail", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
