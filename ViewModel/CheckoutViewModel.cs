﻿using demo_02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demo_02.ViewModel
{
    public class CheckoutViewModel
    {
        public Customer customer { get; set; }
        public Cart Cart { get; set; }
        public double ShopingCartTotal { get; set; }
    }
}