using demo_02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;

namespace demo_02.Controllers
{
    public class WorkRoomController : Controller
    {
        // GET: WorkRoom
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var product = db.Products
                .Include(p => p.Room)
                .Where(p => p.IdRoom == 4);
            return View(product.ToList());
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
    }
}