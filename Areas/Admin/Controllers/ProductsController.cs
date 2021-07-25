using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using demo_02.Models;

namespace demo_02.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Room);
            return View(products.ToList());
        }

        // GET: Admin/Products/Details/5
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

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            ViewBag.IdRoom = new SelectList(db.Rooms, "IdRoom", "NameRoom");
            Product pro = new Product();
            return View(pro);
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProduct,NameProduct,Dimension,Materials,Color,Price,IdRoom")] Product product,HttpPostedFileBase image)
        {

            if (image!= null &&image.ContentLength>0)
            {
                string fileName = System.IO.Path.GetFileName(image.FileName);
                string urlImage =   Server.MapPath("~/Images/"+fileName);
                image.SaveAs(urlImage);
                product.Picture1 = "/Images/" + fileName;
                
                
            }



            if (product.ImageUpload2 != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(product.ImageUpload2.FileName);
                string extension = Path.GetExtension(product.ImageUpload2.FileName);
                fileName = fileName + extension;
                product.Picture2 = "~/Images/" + fileName;
                product.ImageUpload2.SaveAs(Path.Combine(Server.MapPath("~/Images/"), fileName));
            }

            if (product.ImageUpload3 != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(product.ImageUpload3.FileName);
                string extension = Path.GetExtension(product.ImageUpload3.FileName);
                fileName = fileName + extension;
                product.Picture3 = "~/Images/" + fileName;
                product.ImageUpload3.SaveAs(Path.Combine(Server.MapPath("~/Images/"), fileName));
            }


            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdRoom = new SelectList(db.Rooms, "IdRoom", "NameRoom", product.IdRoom);
            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(string id)
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
            ViewBag.IdRoom = new SelectList(db.Rooms, "IdRoom", "NameRoom", product.IdRoom);
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProduct,NameProduct,Dimension,Materials,Color,Price,IdRoom,Picture1,Picture2,Picture3")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdRoom = new SelectList(db.Rooms, "IdRoom", "NameRoom", product.IdRoom);
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(string id)
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

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
