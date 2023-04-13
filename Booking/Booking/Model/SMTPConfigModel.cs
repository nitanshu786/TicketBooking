using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Model
{
    public class SMTPConfigModel
    {
        public string PrimaryDomain { get; set; }
        public int PrimaryPort { get; set; }
        public string UsernameEmail { get; set; }
        public string UsernamePassward { get; set; }
        public string FromEmail { get; set; }
        public string ToEmail { get; set; }
        public string CcEmail { get; set; }



        //public string PrimaryDomain { get; set; }
        //public string SenderDispalyName { get; set; }
        //public string UsernameEmail { get; set; }
        //public string UsernamePassward { get; set; }
        ////public string host { get; set; }
        //public int PrimaryPort { get; set; }
        //public bool EnableSSl { get; set; }
        //public bool UseDefaultCredentials { get; set; }
        //public bool IsBodyHTML { get; set; }
        //public List<string> ToEmails { get; set; }
        //public string Subject { get; set; }
        //public string Body { get; set; }
        //public string FromEmail { get; set; }
        //public string CcEmail { get; set; }
    }
}
