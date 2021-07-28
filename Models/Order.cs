using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace demo_02.Models
{
    public class Order
    {

        public int Id { get; set; }

        [Required]
        [Display(Name = "Ngày đặt hàng")]
        public DateTime OrderDay { get; set; }

        [Display(Name = "Tổng đơn hàng")]
        public decimal OrderTotal { get; set; }


        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }

        public Order() { }
    }
}