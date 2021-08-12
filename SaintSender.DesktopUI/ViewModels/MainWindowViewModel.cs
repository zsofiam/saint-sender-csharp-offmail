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
        private readonly IBackupService _backupService;
        private readonly IEnviromentService _enviromentService;

        private IList<EmailInfo> _emailInfos;

        /// <summary>
        /// Whenever a property value changed the subscribed event handler is called.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowViewModel(IUserService userService)
        {
            _userService = userService;
            _emailService = new EmailService();
            _backupService = new BackupService();
            _enviromentService = new EnviromentService();
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

        public bool IsOnline()
        {
            return _enviromentService.IsOnline();
        }

        public void LoadBackupEmails(ListView view, int page)
        {
            _emailInfos = _backupService.LoadEmails(_userService.GetSessionAddress(), (page * 25) - 24, page * 25);

            view.ItemsSource = _emailInfos;
        }

        public void RefreshEmails(ListView view, int page)
        {
            _emailInfos = _emailService.GetEmails(_userService.GetSessionAddress(), _userService.GetSessionPassword(), (page*25)-24, page*25);

            view.ItemsSource = _emailInfos;
        }

        public void SearchEmails(ListView view, string searchTerms)
        {
            view.ItemsSource = _emailService.GetEmails(_userService.GetSessionAddress(), _userService.GetSessionPassword(), searchTerms);
        }

        public bool SaveBackup()
        {
            if (_backupService.SaveBackup(_userService.GetSessionAddress(), _emailInfos)) return true;
            else return false;
        }

        public bool BackupExists()
        {
            return _backupService.BackupExitsts(_userService.GetSessionAddress());
        }
    }
}
