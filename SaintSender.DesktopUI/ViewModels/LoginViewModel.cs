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
    class LoginViewModel : INotifyPropertyChanged
    {
        private string _email;
        //private string _password;
        private readonly IUserService _userService;

        public String Email
        {
            get { return _email; }
            set
            {
                _email = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Email)));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public LoginViewModel()
        {
            _userService = new UserService();
        }

        public void Login()
        {
            if (!_userService.IsValidEmail(Email))
            {
                MessageBox.Show("Invalid email address!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
