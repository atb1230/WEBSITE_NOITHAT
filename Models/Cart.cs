using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace demo_02.Models
{
    public class Cart
    {
        List<Item> items = new List<Item>();

        public IEnumerable<Item> Item
        {
            get { return items; }
        }

        public void AddToCart(Product product, int qty = 1)
        {
            var item = items.FirstOrDefault(s => s.Product.IdProduct == product.IdProduct);
            if (item == null)
            {
                items.Add(new Item
                {
                    Product = product,
                    Quatity = qty

                });
            }
            else
            {

                item.Quatity += qty;
            }
        }

        public void UpdateQty(string id, int qty)
        {
            var item = items.Find(s => s.Product.IdProduct == id);
            if (item != null)
            {
                item.Quatity = qty;
            }
        }

        //tính tổng tiền
        public double TotalMoney()
        {
            var total = items.Sum(s => s.Product.Price * s.Quatity);
            return (double)total;
        }

        //xóa item khỏi cart
        public void Remove(string id)
        {
            items.RemoveAll(s => s.Product.IdProduct == id);
        }

        //dem so luong san pham trong gio hang
        public int TotalQuantity()
        {
            return items.Sum(s => s.Quatity);
        }

        //clear gio hang sau khi da thanh toan
        public void ClearCart()
        {
            items.Clear();
        }




    }
}
