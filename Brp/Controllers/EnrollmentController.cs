﻿using System;
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
            return View();
        }

    }
}