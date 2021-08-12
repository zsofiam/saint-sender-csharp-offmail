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


            //In case we are logged in, fetch emails
            if (userService.IsLoggedIn()) _vm.refreshEmails(EmailListVisual);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _vm.refreshEmails(EmailListVisual);
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

        private void RefreshVisual_Click(object sender, RoutedEventArgs e)
        {
            _vm.refreshEmails(EmailListVisual);
        }

        private void getSelectedEmail(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            EmailInfo emailinfo = (EmailInfo)EmailListVisual.SelectedItems[0];
            System.Windows.MessageBox.Show(emailinfo.Subject);
        }
    }
}
