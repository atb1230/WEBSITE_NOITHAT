﻿using demo_02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace demo_02.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        //dang nhap
        [HttpPost]
        public ActionResult Login(Customer customer)
        {
            var login = db.Customers.Where(s => s.Username == customer.Username && s.Password == customer.Password).FirstOrDefault();

            if (login == null)
            {
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng");
                return View();

            }
            else
            {
                customer.isLogin = true;
                Session["Customer"] = login;
                ViewBag.Thongbao = "Đăng nhập thành công";
                return RedirectToAction("Index", "Home");
            }
        }

        //ho so
        public ActionResult ProfileName()
        {
            if (Session["UserLogin"] != null)
            {
                ViewBag.Profile = ((Customer)Session["UserLogin"]).Username;
                return PartialView();
            }
            ViewBag.Profile = "Đăng nhập/ Đăng ký";
            return PartialView();
        }
        //dang xuat
        public ActionResult LogOut()
        {

            Session["Customer"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }
        //dang ky
        [HttpPost]
        public ActionResult Register(Customer newcustomer)
        {
            if (ModelState.IsValid)
            {
                var check = db.Customers.FirstOrDefault(s => s.Email == newcustomer.Email);
                if (check == null)
                {
                    Customer customer = new Customer()
                    {
                        fullname = newcustomer.fullname,
                        Username = newcustomer.Username,
                        Password = newcustomer.Password,
                        Email = newcustomer.Email,
                        Address = newcustomer.Address,
                        Phone = newcustomer.Phone

                    };
                    db.Customers.Add(newcustomer);
                    db.SaveChanges();
                    ViewBag.ThongBao = "Đăng nhập thành công";
                    return RedirectToAction("Login", "Customer");
                }
            }
            else
            {
                ViewBag.Error = "Tài khoản này đã tồn tại!";
                return View();
            }

            return View();

        }

        public ActionResult Details(int? id)
        {
            int customerId = id ?? default(int);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Details([Bind(Include = "Id,Username,Password,fullname,Address,Email,Phone")] Customer customer)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(customer).State = System.Data.Entity.EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Details");
        //    }
        //    return View(customer);
        //}


        //Thay doi mat khau
        //[HttpPost]
        //public ActionResult ChangePwd (int id, string newPwd)
        //{
        //    var customer = db.Customers.Where(x => x.Id == id).FirstOrDefault();
        //    if(customer != null)
        //    {
        //        customer.Password = newPwd;
        //        db.SaveChanges();
        //        ViewBag.ThongBao = "Thay đổi mật khẩu thành công";
        //        return RedirectToAction("Details");
        //    }
        //    return View(customer);
        //}

        [HttpPost]
        public JsonResult UpdateInfo(int id, string fullName, string address, string phone, string email)
        {

            var customer = db.Customers.Where(x => x.Id == id).FirstOrDefault();
            customer.fullname = fullName;

            customer.Address = address;
            customer.Phone = phone;
            customer.Email = email;

            UpdateModel(customer);
            db.SaveChanges();

            Session["Customer"] = customer;

            return Json("Success", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ChangePwd(int id, string newPwd)
        {
            var customer = db.Customers.Where(x => x.Id == id).FirstOrDefault();
            if (customer != null)
            {
                customer.Password = newPwd;
                UpdateModel(customer);
                db.SaveChanges();
                Session["Customer"] = customer;
                return Json("Success", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("CannotFindCustomer", JsonRequestBehavior.AllowGet);
            }
        }

    }
}