using SaintSender.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SaintSender.Core.Services
{
    public class EnviromentService : IEnviromentService
    {
        public bool IsOnline()
        {
            try
            {
                using (WebClient client = new WebClient())
                using (Stream stream = client.OpenRead("http://www.google.com"))
                {
                    return true;   
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
