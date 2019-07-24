using Brp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DotNetOpenAuth.GoogleOAuth2;
using Microsoft.AspNet.Membership.OpenAuth;
using System.Collections.Specialized;
using System.Web.Security;

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
                response = new ServiceClient().RunPut<ConsumerRequest, ConsumerResponse>(objReq, url);
                return View(response);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public ActionResult Consumer()
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
                response = new ServiceClient().RunPut<ConsumerRequest, ConsumerResponse>(objReq, url);
                return View("Consumer", response);
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

        public ActionResult RedirectToGoogle()
        {
            string provider = "google";
            string returnUrl = "";
            return new ExternalLoginResult(provider, Url.Action("ExternalLoginCallback", new { ReturnUrl = returnUrl }));
        }
        internal class ExternalLoginResult : ActionResult
        {
            public ExternalLoginResult(string provider, string returnUrl)
            {
                Provider = provider;
                ReturnUrl = returnUrl;
            }

            public string Provider { get; private set; }
            public string ReturnUrl { get; private set; }

            public override void ExecuteResult(ControllerContext context)
            {
                OpenAuth.RequestAuthentication(Provider, ReturnUrl);
            }
        }

        [AllowAnonymous]
        public ActionResult ExternalLoginCallback(string returnUrl)
        {
            string ProviderName = OpenAuth.GetProviderNameFromCurrentRequest();

            if (ProviderName == null || ProviderName == "")
            {
                NameValueCollection nvs = Request.QueryString;
                if (nvs.Count > 0)
                {
                    if (nvs["state"] != null)
                    {
                        NameValueCollection provideritem = HttpUtility.ParseQueryString(nvs["state"]);
                        if (provideritem["__provider__"] != null)
                        {
                            ProviderName = provideritem["__provider__"];
                        }
                    }
                }
            }

            GoogleOAuth2Client.RewriteRequest();

            var redirectUrl = Url.Action("ExternalLoginCallback", new { ReturnUrl = returnUrl });
            var retUrl = returnUrl;
            var authResult = OpenAuth.VerifyAuthentication(redirectUrl);

            if (!authResult.IsSuccessful)
            {
                return Redirect(Url.Action("ConsumerSummary", "Enrollment"));
            }

            // User has logged in with provider successfully
            // Check if user is already registered locally
            //You can call you user data access method to check and create users based on your model
            if (OpenAuth.Login(authResult.Provider, authResult.ProviderUserId, createPersistentCookie: false))
            {
                //return Redirect(Url.Action("Contact", "Home"));
                return Redirect(Url.Action("ConsumerSummary", "Enrollment"));
            }

            //Get provider user details
            string ProviderUserId = authResult.ProviderUserId;
            string ProviderUserName = authResult.UserName;

            string Email = null;
            if (Email == null && authResult.ExtraData.ContainsKey("email"))
            {
                Email = authResult.ExtraData["email"];
            }

            if (User.Identity.IsAuthenticated)
            {
                // User is already authenticated, add the external login and redirect to return url
                OpenAuth.AddAccountToExistingUser(ProviderName, ProviderUserId, ProviderUserName, User.Identity.Name);
                //return Redirect(Url.Action("Contact", "Home"));
                return Redirect(Url.Action("ConsumerSummary", "Enrollment"));
                //return Redirect(Url.Action("Index", "Home"));
            }
            else
            {
                // User is new, save email as username
                string membershipUserName = Email ?? ProviderUserId;
                var createResult = OpenAuth.CreateUser(ProviderName, ProviderUserId, ProviderUserName, membershipUserName);

                if (!createResult.IsSuccessful)
                {
                    ViewBag.Message = "User cannot be created";
                    return View();
                }
                else
                {
                    // User created
                    if (OpenAuth.Login(ProviderName, ProviderUserId, createPersistentCookie: false))
                    {
                        //return Redirect(Url.Action("Contact", "Home"));
                        return Redirect(Url.Action("ConsumerSummary", "Enrollment"));
                    }
                }
            }

            return View();
        }



        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            //Call https://www.google.com/accounts/Logout if you want to logoff at provider
            return Redirect(Url.Action("Index", "Home"));
        }
    }
}