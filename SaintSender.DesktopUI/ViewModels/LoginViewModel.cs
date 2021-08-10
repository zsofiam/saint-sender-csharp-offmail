﻿using SaintSender.Core.Interfaces;
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
        private readonly IUserService _userService;
        private readonly IEnviromentService _enviromentService;

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
            _enviromentService = new EnviromentService();
        }

        public void Login(string password)
        {
            // Make sure our credintals are not empty
            if (Email == string.Empty || password == string.Empty)
            {
                MessageBox.Show("Please enter an email address and a password!", "No internet", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // See if we are online
            if (!_enviromentService.IsOnline())
            {
                MessageBox.Show("Please check your connection!", "No internet", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Validate email address
            if (!_userService.IsValidEmail(Email))
            {
                MessageBox.Show("Invalid email address!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Auth the account
            if (!_userService.canAuthenticate(Email, password))
            {
                MessageBox.Show("Wrong credintals!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Actually logged in
            MessageBox.Show("Authed");
        }
    }
}
