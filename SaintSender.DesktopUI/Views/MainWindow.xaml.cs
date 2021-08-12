using SaintSender.DesktopUI.ViewModels;
using System.Windows;

//Debug for the login
using SaintSender.DesktopUI.Views;
using SaintSender.Core.Services;
using SaintSender.Core.Interfaces;

namespace SaintSender.DesktopUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _vm;
        private IUserService userService;

        public MainWindow()
        {
            //Create an user service we will use EVERYWHERE!
            userService = new UserService();

            // set DataContext to the ViewModel object
            _vm = new MainWindowViewModel(userService);
            DataContext = _vm;
            InitializeComponent();

            // Auto Login from storage
            if (_vm.AutoLogin())
            {
                this.Visibility = Visibility.Visible;
            }
            // Can't login
            else
            {
                this.Visibility = Visibility.Hidden;

                Login login = new Login(this, userService);
                login.Show();
            }
        }

        private void Logout_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            _vm.logout();
            Login login = new Login(this, userService);
            login.Show();
        }

        private void Forget_Me_Button_Click(object sender, RoutedEventArgs e)
        {
            _vm.ForgetMe();
        }
    }
}
