using Brp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Brp.Controllers
{
    public class EnrollmentController : Controller
    {
        // GET: Enrollment
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult ConsumerSummary()
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
                return View("Consumer", response);
            }
            catch (Exception ex)
            {

                throw ex;
            }
          
        }

    }
}