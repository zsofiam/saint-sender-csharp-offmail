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
