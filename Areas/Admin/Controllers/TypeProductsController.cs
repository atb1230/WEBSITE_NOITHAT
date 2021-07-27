using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using demo_02.Models;

namespace demo_02.Areas.Admin.Controllers
{
    public class TypeProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/TypeProducts
        public ActionResult Index()
        {
            return View(db.TypeProducts.ToList());
        }

        // GET: Admin/TypeProducts/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeProduct typeProduct = db.TypeProducts.Find(id);
            if (typeProduct == null)
            {
                return HttpNotFound();
            }
            return View(typeProduct);
        }

        // GET: Admin/TypeProducts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/TypeProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTypeProduct,NameTypeProdcut")] TypeProduct typeProduct)
        {
            if (ModelState.IsValid)
            {
                db.TypeProducts.Add(typeProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typeProduct);
        }

        // GET: Admin/TypeProducts/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeProduct typeProduct = db.TypeProducts.Find(id);
            if (typeProduct == null)
            {
                return HttpNotFound();
            }
            return View(typeProduct);
        }

        // POST: Admin/TypeProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTypeProduct,NameTypeProdcut")] TypeProduct typeProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typeProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typeProduct);
        }

        // GET: Admin/TypeProducts/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeProduct typeProduct = db.TypeProducts.Find(id);
            if (typeProduct == null)
            {
                return HttpNotFound();
            }
            return View(typeProduct);
        }

        // POST: Admin/TypeProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TypeProduct typeProduct = db.TypeProducts.Find(id);
            db.TypeProducts.Remove(typeProduct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
