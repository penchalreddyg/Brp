using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Brp.Models
{
    public class ConsumerDetailsRequest
    {
        public Passport PassPort { get; set; }       
        public string RequestBy { get; set; }
        public int ConsumerID { get; set; }
        public int ServiceID { get; set; }
        public int GrantID { get; set; }
    }
}