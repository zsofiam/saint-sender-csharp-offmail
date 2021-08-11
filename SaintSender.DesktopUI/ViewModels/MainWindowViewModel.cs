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
        //private string _name;
        //private string _greeting;
        //private readonly IGreetService _greetService;
        private readonly IUserService _userService;

        /// <summary>
        /// Whenever a property value changed the subscribed event handler is called.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        internal void logout()
        {
            _userService.SetLoggedIn(false);
        }

        internal void ForgetMe()
        {
            _userService.DeleteCredentials();
        }

        /// <summary>
        /// Gets or sets value of Greeting.
        /// </summary>
        /*public string Greeting
        {
            get { return _greeting; }
            set
            {
                _greeting = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Greeting)));
            }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }*/

        public MainWindowViewModel()
        {
            //Name = string.Empty;
            //_greetService = new GreetService();
            _userService = new UserService();
        }

        public bool AutoLogin()
        {
            return _userService.AutoLogin();
        }

        public bool IsLoggedIn()
        {
            return _userService.IsLoggedIn();
        }

        /// <summary>
        /// Call a vendor service and apply its value into <see cref="Greeting"/> property.
        /// </summary>
        /*public void Greet()
        {
            Greeting = _greetService.Greet(Name);
        }*/
    }
}
