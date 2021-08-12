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
        private string _body;
        private bool _read;

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
