using demo_02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demo_02.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db;
        public HomeController()
        {
            db = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }
    }
}