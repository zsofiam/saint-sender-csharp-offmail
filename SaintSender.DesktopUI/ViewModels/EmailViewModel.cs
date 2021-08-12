using SaintSender.Core.Services;
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
        private readonly EmailInfo _emailInfo;

        public event PropertyChangedEventHandler PropertyChanged;

        public EmailViewModel(EmailInfo emailInfo)
        {
            _emailInfo = emailInfo;
          
        }

        internal void SendReply()
        {
            MessageBox.Show("Message has been sent!");
        }
    }
}
