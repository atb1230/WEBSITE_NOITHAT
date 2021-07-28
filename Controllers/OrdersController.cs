using demo_02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace demo_02.Controllers
{
    public class OrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Orders
        public ActionResult Index(int id)
        {
            var orders = db.Orders.Include(o => o.Customer)
                .Where(p => p.CustomerId == id);
            return View(orders.ToList());
        }
        public ActionResult Details(int id)
        {
            var orderDetails = db.OrderDetails.Include(o => o.Order).Include(o => o.Product).Where(p => p.OrderId == id);
            return View(orderDetails.ToList());
        }
    }
}