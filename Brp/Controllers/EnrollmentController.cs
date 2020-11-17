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
        public ActionResult Logout()
        {
            return View();
        }
        public ActionResult Recover()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Dashboard()
        {
            try
            {
                var response = new ConsumerResponse();
                var objReq = new ConsumerRequest();
                objReq.RecordsReturned = 50;
                objReq.GrantID = 5;
                objReq.RequestBy = "BIMInsights-QA";
                objReq.ServiceId = 1400;
                objReq.PassPort = new Passport { PassKey = "BIMInsightsQA", PassPhrase = "5E758B95-FC80-414A-AA20-493DB315B90C" };
                var url = "api/EnrollmentServices/ConsumerStates";
                response = new ServiceClient().RunPut<ConsumerRequest, ConsumerResponse>(objReq, url);
                return View("Dashboard", response);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public ActionResult AddConsumer()
        {
            return View();
        }


        public ActionResult ConsumerSummary()
        {
            try
            {
                var response = new ConsumerResponse();
                var objReq = new ConsumerRequest();
                objReq.RecordsReturned = 50;
                objReq.GrantID = 5;
                objReq.RequestBy = "BIMInsights-QA";
                objReq.ServiceId = 1400;
                objReq.PassPort = new Passport { PassKey = "BIMInsightsQA", PassPhrase = "5E758B95-FC80-414A-AA20-493DB315B90C" };
                var url = "api/EnrollmentServices/ConsumerStates";
                response = new ServiceClient().RunPut<ConsumerRequest, ConsumerResponse>(objReq, url);
                return View("ConsumerSummary", response);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public PartialViewResult GetConsumerProfile(int consumerId)
        {
            try
            {
                var response = new ConsumerResponse();
                var objReq = new ConsumerDetailsRequest();
                objReq.GrantID = 3;
                objReq.RequestBy = "Hosted Enrollment";
                objReq.ConsumerID = consumerId;
                objReq.ServiceID = 142;
                objReq.PassPort = new Passport { PassKey = "HEP-QA", PassPhrase = "9D17B253-D061-4343-90C3-583C78475304" };
                var url = "api/EnrollmentServices/ConsumerProfile";
                response = new ServiceClient().RunPut<ConsumerDetailsRequest, ConsumerResponse>(objReq, url);
                return PartialView("_ConsumerProfile", response);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}