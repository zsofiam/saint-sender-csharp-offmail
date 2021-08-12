using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintSender.Core.Services
{
    public class EmailInfo
    {
        private string _sender;
        private DateTime _recieved;
        private string _subject;
        private bool _read;

        public EmailInfo(string sender, DateTime received, string subject, bool read)
        {
            _sender = sender;
            _recieved = received;
            _subject = subject;
            _read = read;
        }
    }
}
