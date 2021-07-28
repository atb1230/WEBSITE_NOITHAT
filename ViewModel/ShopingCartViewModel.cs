using demo_02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace  demo_02.ViewModel
{
    public class ShopingCartViewModel
    {
        public Cart Cart { get; set; }
        public decimal ShopingCartTotal { get; set; }
        
    }
}