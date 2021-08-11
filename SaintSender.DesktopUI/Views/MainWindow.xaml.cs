using SaintSender.DesktopUI.ViewModels;
using System.Windows;

//Debug for the login
using SaintSender.DesktopUI.Views;

namespace SaintSender.DesktopUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _vm;

        public MainWindow()
        {
            // set DataContext to the ViewModel object
            _vm = new MainWindowViewModel();
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

                Login login = new Login(this);
                login.Show();
            }
        }

        private void GreetBtn_Click(object sender, RoutedEventArgs e)
        {
            // dispatch user interaction to view model
            //_vm.Greet();
        }
    }
}
