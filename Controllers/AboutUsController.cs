using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demo_02.Controllers
{
    public class AboutUsController : Controller
    {
        // GET: AboutUs
        public ActionResult AboutUsIndex()
        {
            return View();
        }
    }
}