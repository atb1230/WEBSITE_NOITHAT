﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace  demo_02.ViewModel
{
    public class ChangePasswordViewModel
    {
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}