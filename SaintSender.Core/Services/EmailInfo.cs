using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintSender.Core.Services
{
    public class EmailInfo : INotifyPropertyChanged
    {
        private string _sender;
        private DateTime _recieved;
        private string _subject;
        private string _body;
        private bool _read;

        public event PropertyChangedEventHandler PropertyChanged;

        public String Sender
        {
            get { return _sender; }
            set
            {
                _sender = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Sender)));
            }
        }
        public DateTime Received
        {
            get { return _recieved; }
            set
            {
                _recieved = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Received)));
            }
        }
        public String Subject
        {
            get { return _subject; }
            set
            {
                _subject = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Subject)));
            }
        }
        public String Body
        {
            get { return _body; }
            set
            {
                _body = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Body)));
            }
        }
        public bool Read
        {
            get { return _read; }
            set
            {
                _read = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Read)));
            }
        }

        public EmailInfo(string sender, DateTime received, string subject, string body, bool read)
        {
            _sender = sender;
            _recieved = received;
            _subject = subject;
            _body = body;
            _read = read;
        }
    }
}
