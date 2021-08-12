using SaintSender.Core.Interfaces;
using SaintSender.DesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SaintSender.DesktopUI.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// WARNING: Closing this window won't end the app!
    /// </summary>
    public partial class Login : Window
    {
        private LoginViewModel _vm;
        private Window MainWindow;

        public Login(Window main, IUserService userService)
        {
            _vm = new LoginViewModel(userService);
            DataContext = _vm;

            MainWindow = main;
            InitializeComponent();
        }

        private void LoginVisual_Click(object sender, RoutedEventArgs e)
        {
            //Try to login
            //I've read to NEVER store passwords in plaintext, so I just decided to pass it as an argument here
            if (_vm.Login(PasswordVisual.Password, RememberMeVisual.IsChecked.Value))
            {
                this.Visibility = Visibility.Hidden;

                MainWindow.Visibility = Visibility.Visible;
            }
        }
    }
}
