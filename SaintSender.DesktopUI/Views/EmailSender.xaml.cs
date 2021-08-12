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
    /// Interaction logic for EmailSender.xaml
    /// </summary>
    public partial class EmailSender : Window
    {
        EmailSenderViewModel _vm;

        public EmailSender()
        {
            _vm = new EmailSenderViewModel();

            InitializeComponent();
        }

        private void SendVisual_Click(object sender, RoutedEventArgs e)
        {
            if (!_vm.IsValidEmail(ToVisual.Text) || (CCVisual.Text != "" && !_vm.IsValidEmail(CCVisual.Text)))
            {
                MessageBox.Show("One of the entered email addresses are invalid!", "Invalid email address!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

            if (_vm.SendEmail(ToVisual.Text, CCVisual.Text, SubjectVisual.Text, MessageVisual.Text))
            {
                MessageBox.Show("Email was sent successfully to "+ToVisual.Text+"!", "Email sent", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else MessageBox.Show("Couldn't send the email!", "Sending error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void CloseVisual_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Close the window without saving my content?", "Closing the window", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }
    }
}
