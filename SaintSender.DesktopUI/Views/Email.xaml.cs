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
    /// Interaction logic for Email.xaml
    /// </summary>
    public partial class Email : Window
    {
        private EmailViewModel _vm;
        public Email()
        {
            _vm = new EmailViewModel();
            DataContext = _vm;
            InitializeComponent();
        }

        private void Reply_Button_Click(object sender, RoutedEventArgs e)
        {
            ReplyText.Visibility = Visibility.Visible;
            ReplyButton.Visibility = Visibility.Visible;
        }

        private void Send_Reply_Button_Click(object sender, RoutedEventArgs e)
        {
            _vm.SendReply();
            Close();
        }
    }
}
