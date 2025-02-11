﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace demo_02.Models
{
    public class Customer
    {

        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name = "Tài khoản")]
        public string Username { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Tên khách hàng")]
        public string fullname { get; set; }
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }
        public string Email { get; set; }
        [Display(Name = "Điện thoại")]
        public string Phone { get; set; }

        [NotMapped]
        public bool isLogin { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}