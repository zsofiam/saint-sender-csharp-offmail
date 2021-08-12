using SaintSender.Core.Interfaces;
using SaintSender.Core.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Controls;

namespace SaintSender.DesktopUI.ViewModels
{
    /// <summary>
    /// ViewModel for Main window. Contains all shown information
    /// and necessary service classes to make view functional.
    /// </summary>
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;

        private IList<EmailInfo> _emailInfos;

        /// <summary>
        /// Whenever a property value changed the subscribed event handler is called.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowViewModel(IUserService userService)
        {
            _userService = userService;
            _emailService = new EmailService();
        }

        internal void logout()
        {
            _userService.SetLoggedIn(false);
            _userService.DeleteSession();
        }

        internal void ForgetMe()
        {
            _userService.DeleteCredentials();
        }

        public bool AutoLogin()
        {
            return _userService.AutoLogin();
        }

        public bool IsLoggedIn()
        {
            return _userService.IsLoggedIn();
        }

        public void refreshEmails(ListView view)
        {
            _emailInfos = _emailService.GetEmails(_userService.GetSessionAddress(), _userService.GetSessionPassword(), 1, 25);

            view.ItemsSource = _emailInfos;
        }
    }
}
