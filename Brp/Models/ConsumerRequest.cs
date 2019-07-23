using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Brp.Models
{
    public class ConsumerRequest
    {
        public Passport PassPort { get; set; }
        public int RecordsReturned { get; set; }
        public string RequestBy { get; set; }
        public int ServiceId { get; set; }
        public int GrantID { get; set; }
    }

    public class Passport
    {
        public string PassKey { get; set; }
        public string PassPhrase { get; set; }
    }
}