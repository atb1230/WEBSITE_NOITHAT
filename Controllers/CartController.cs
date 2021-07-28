using demo_02.Models;
using demo_02.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demo_02.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();
        static List<Cart> listItem = new List<Cart>();
        [Authorize]
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }

        //them sp vao gio hang

        public ActionResult AddtoCart(string id)
        {
            //if (Session["Customer"] == null)
            //{
            //    return RedirectToAction("Login", "Customer");
            //}
            //else
            {
                var product = db.Products.SingleOrDefault(s => s.IdProduct.Equals(id));
                if (product != null)
                {
                    GetCart().AddToCart(product);
                }
                return RedirectToAction("ShowCart", "Cart");
            }
        }

        //xem gio hang
        public ActionResult ShowCart()
        {
            //if (Session["Customer"] == null)
            //{
            //    return RedirectToAction("Login", "Customer");
            //}
            if (Session["Cart"] == null)
            {
                return RedirectToAction("ShowCart", "ShopingCart");
            }
            Cart cart = Session["Cart"] as Cart;
            return View(cart);
        }
        //update so luong gio hang
        public ActionResult UpdateQuantity(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            string Idproduct = form["ID_Product"];
            int quantity = int.Parse(form["Quantity"]);

            cart.UpdateQty(Idproduct, quantity);
            return RedirectToAction("ShowCart", "Cart");
        }

        //remove item
        public ActionResult RemoveCart(string id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.Remove(id);

            return RedirectToAction("ShowCart", "Cart");
        }
        public PartialViewResult BagCart()
        {
            int totalItem = 0;
            Cart cart = Session["Cart"] as Cart;
            if (cart != null)

                totalItem = cart.TotalQuantity();
            ViewBag.QuantityCart = totalItem;
            return PartialView("BagCart");

        }



        public ActionResult Checkout()
        {
            Cart cart = Session["Cart"] as Cart;
            if (Session["Customer"] == null || Session["Customer"].ToString() == "")
            {
                return RedirectToAction("Login", "Customer");
            }
            if (Session["Cart"] == null)
            {
                return RedirectToAction("Index", "Product");
            }

            CheckoutViewModel viewModel = new CheckoutViewModel
            {
                customer = (Customer)Session["Customer"],
                Cart = Session["Cart"] as Cart
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Checkout(FormCollection form)
        {
            try
            {
                Cart cart = Session["Cart"] as Cart;
                Customer customer = (Customer)Session["Customer"];
                Order order = new Order();

                var tongtien = cart.TotalMoney().ToString();
                order.CustomerId = customer.Id;
                order.OrderDay = DateTime.Now;
                order.OrderTotal = Convert.ToDecimal(tongtien);
                db.Orders.Add(order);
                foreach (var item in cart.Item)
                {
                    OrderDetail orderDetail = new OrderDetail();
                    orderDetail.OrderId = order.Id;
                    orderDetail.ProductId = item.Product.IdProduct;
                    orderDetail.Price = item.Product.Price;
                    orderDetail.Qty = item.Quatity;
                    db.OrderDetails.Add(orderDetail);
                }
                db.SaveChanges();
                cart.ClearCart();
                return RedirectToAction("OrderSuccess", "Cart");
            }
            catch
            {
                return Content("Kiểm tra lại thông tin khách hàng");
            }
        }

        public ActionResult OrderSuccess()
        {
            return View();
        }
    }
}