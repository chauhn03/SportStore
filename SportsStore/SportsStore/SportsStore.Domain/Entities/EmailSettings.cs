using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class EmailSettings
    {
        public string MailToAddress = "chauhn.k28@gmail.com";
        public string MailFromAddress = "chauhn.k28@gmail.com";
        public bool UseSsl = true;
        public string Username = "chauhn.k28@gmail.com";
        public string Password = "Chau.Hoang86";
        public string ServerName = "smtp.gmail.com";
        public int ServerPort = 587;
        public bool WriteAsFile = false;
        public string FileLocation = @"c:\sports_store_emails";
    }
}
