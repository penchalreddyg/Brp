using Brp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace Brp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                var response = new ConsumerResponse();
                var objReq = new ConsumerRequest();
                objReq.RecordsReturned = 5;
                objReq.GrantID = 5;
                objReq.RequestBy = "BIMInsights-QA";
                objReq.ServiceId = 1400;
                objReq.PassPort = new Passport { PassKey = "BIMInsightsQA", PassPhrase = "5E758B95-FC80-414A-AA20-493DB315B90C" };
                var url = "api/EnrollmentServices/ConsumerStates";
                response = new ServiceClient().RunGetAsync<ConsumerRequest, ConsumerResponse>(objReq, url);
                return View(response);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public  ActionResult Consumer()
        {
            try
            {
                var response = new ConsumerResponse();
                var objReq = new ConsumerRequest();
                objReq.RecordsReturned = 5;
                objReq.GrantID = 5;
                objReq.RequestBy = "BIMInsights-QA";
                objReq.ServiceId = 1400;
                objReq.PassPort = new Passport { PassKey = "BIMInsightsQA", PassPhrase = "5E758B95-FC80-414A-AA20-493DB315B90C" };
                var url = "api/EnrollmentServices/ConsumerStates";
                response = new ServiceClient().RunGetAsync<ConsumerRequest, ConsumerResponse>(objReq, url);
                return View("consumer",response);
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public T DeSerialize<T>(string input) where T : class
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));

            using (StringReader sr = new StringReader(input))
            {
                return (T)ser.Deserialize(sr);
            }
        }
    }
}