using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SaintSender.DesktopUI.ViewModels
{
    class EmailViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        internal void SendReply()
        {
            _ = MessageBox.Show("Message has been sent!", "", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
