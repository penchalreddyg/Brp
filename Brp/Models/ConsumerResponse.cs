using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Brp.Models
{
    public  class ConsumerResponse
    {
        [JsonProperty("ConsumerStates")]
        public List<ConsumerState> ConsumerStates { get; set; }

        [JsonProperty("Error")]
        public Error Error { get; set; }
    }
    public  class ConsumerState
    {
        [JsonProperty("PartnerID")]
        public long PartnerId { get; set; }

        [JsonProperty("ConsumerID")]
        public long ConsumerId { get; set; }

        [JsonProperty("ConsumerName")]
        public string ConsumerName { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Registered")]
        public bool Registered { get; set; }

        [JsonProperty("DemoInfoReceived")]
        public bool DemoInfoReceived { get; set; }

        [JsonProperty("RedirectComplete")]
        public bool RedirectComplete { get; set; }

        [JsonProperty("BankInfoReceived")]
        public bool BankInfoReceived { get; set; }

        [JsonProperty("IdentityCheckComplete")]
        public bool IdentityCheckComplete { get; set; }

        [JsonProperty("LastUpdate")]
        public string LastUpdate { get; set; }
    }

    public  class Error
    {
        [JsonProperty("Errors")]
        public object[] Errors { get; set; }
    }
    //public class ConsumerResponse
    //{
    //   // public IList<ConsumerData> ConsumerStates { get; set; }
    //}

    //public class ConsumerData
    //{
    //    private string PartnerID { get; set; }
    //    private int ConsumerID { get; set; }
    //    private string ConsumerName { get; set; }
    //    private string Email { get; set; }
    //    private bool Registered { get; set; }
    //    private bool DemoInfoReceived { get; set; }
    //    private bool RedirectComplete { get; set; }
    //    private bool BankInfoReceived { get; set; }
    //    private bool IdentityCheckComplete { get; set; }
    //    private DateTime LastUpdate { get; set; }

    //}
}