using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Brp.Models
{
    public class ConsumerDetailsResponse
    {
        public ConsumerDetails ConsumerDetails { get; set; }
        public List<ConsumerCDF> ConsumerCDF { get; set; }
        public Error Error { get; set; }
    }
    public class ConsumerDetails
    {
        public int ScoringID { get; set; }
        public string ConsumerName { get; set; }
        public string ConsumerEmail { get; set; }
        public int ConsumerLegacyID { get; set; }
        public bool EnrollmentStopped { get; set; }
        public int PartnerID { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string ApartmentNumber { get; set; }
        public string City { get; set; }
        public string PoBox { get; set; }
        public string StateName { get; set; }
        public string StateAbbreviation { get; set; }
        public string ZipCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
    }

    public class ConsumerCDF
    {
        public int ConsumerCDFID { get; set; }
        public int ConsumerID { get; set; }
        public int PartnerCDFID { get; set; }
        public string ConsumerCDFValue { get; set; }
    }

}