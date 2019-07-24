using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using ServiceStack;

namespace Brp
{
    public class ServiceClient
    {
        public static readonly ServiceClient Instance;

        public ServiceClient() { }

        static ServiceClient()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3
                                                    | SecurityProtocolType.Tls
                                                    | SecurityProtocolType.Tls11
                                                    | SecurityProtocolType.Tls12;
            Instance = new ServiceClient();

        }

        public ResponseT RunPut<RequestT, ResponseT>(RequestT request, string url)
        {
            try
            {
                string clientUrl = Convert.ToString(ConfigurationManager.AppSettings["BaseURL"]);
                using (var client = new JsonServiceClient(clientUrl))
                {
                    var jsonData = JsonConvert.SerializeObject(request);
                    client.Headers.Add("x-http-method-override", "GET");
                    var responseJson = client.Post<ResponseT>(url, jsonData);            
                    return responseJson;

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}