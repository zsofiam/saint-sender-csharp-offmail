using SaintSender.Core.Interfaces;
using SaintSender.Core.Services;
using System;
using System.ComponentModel;

namespace SaintSender.DesktopUI.ViewModels
{
    /// <summary>
    /// ViewModel for Main window. Contains all shown information
    /// and necessary service classes to make view functional.
    /// </summary>
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly IUserService _userService;

        /// <summary>
        /// Whenever a property value changed the subscribed event handler is called.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowViewModel()
        {
            _userService = new UserService();
        }

        internal void logout()
        {
            _userService.SetLoggedIn(false);
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
    }
}
