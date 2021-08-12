using SaintSender.DesktopUI.ViewModels;
using System.Windows;

//Debug for the login
using SaintSender.DesktopUI.Views;
using SaintSender.Core.Services;
using SaintSender.Core.Interfaces;
using System.Windows.Input;

namespace SaintSender.DesktopUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _vm;
        private IUserService _userService;

        private int _page;
        public MainWindow()
        {
            //Create an user service we will use EVERYWHERE!
            _userService = new UserService();

            // set DataContext to the ViewModel object
            _vm = new MainWindowViewModel(_userService);
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

                Login login = new Login(this, _userService);
                login.Show();
            }

            //In case we are logged in, fetch emails
            if (_userService.IsLoggedIn()) _vm.RefreshEmails(EmailListVisual, _page);



            // Events
            SearchTextVisual.KeyDown += new KeyEventHandler(Search_Key);

            // Assigns
            _page = 1;
            LastVisual.IsEnabled = false;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _vm.RefreshEmails(EmailListVisual, _page);
        }

        private void Logout_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            _vm.logout();
            Login login = new Login(this, _userService);
            login.Show();
        }

        private void Forget_Me_Button_Click(object sender, RoutedEventArgs e)
        {
            _vm.ForgetMe();
        }

        private void RefreshVisual_Click(object sender, RoutedEventArgs e)
        {
            _vm.RefreshEmails(EmailListVisual, _page);
        }

        private void Next_Button_Click(object sender, RoutedEventArgs e)
        {
            _page++;
            _vm.RefreshEmails(EmailListVisual, _page);

            // If page become 1 disable button
            if (_page > 1) LastVisual.IsEnabled = true;
        }

        private void Last_Button_Click(object sender, RoutedEventArgs e)
        {
            if (_page == 1) return;

            _page--;
            _vm.RefreshEmails(EmailListVisual, _page);

            // If page become 1 disable button
            if (_page == 1) LastVisual.IsEnabled = false;
        }

        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            _vm.SearchEmails(EmailListVisual, SearchTextVisual.Text);
        }

        private void RemoveSearch_Button_Click(object sender, RoutedEventArgs e)
        {
            SearchTextVisual.Text = "";
            _vm.RefreshEmails(EmailListVisual, _page);
        }

        private void Search_Key(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                _vm.SearchEmails(EmailListVisual, SearchTextVisual.Text);
            }
        }

        private void Backup_Button_Click(object sender, RoutedEventArgs e)
        {
            if (_vm.SaveBackup()) MessageBox.Show("Backup saved!", "Backup", MessageBoxButton.OK, MessageBoxImage.Information);
            else MessageBox.Show("Error while saving backup!", "Backup", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
