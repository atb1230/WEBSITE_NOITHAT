using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace demo_02.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }

        [Display(Name = "Mã sản phẩm")]
        public string ProductId { get; set; }
        public Product Product { get; set; }
        [Display(Name = "Số lượng")]
        public int Qty { get; set; }
        [Display(Name = "Đơn giá")]
        public double Price { get; set; }

        [Display(Name = "Mã đơn hàng")]
        public int OrderId { get; set; }
        public Order Order { get; set; }

    }
}