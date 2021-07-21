using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace demo_02.Models
{
    public class Product
    {
        [Key]
        [Required]
        [StringLength(255)]
        public string IdProduct { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name ="Tên Sản Phẩm")]
        public string NameProduct { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name ="Kích Thước")]
        public string Dimension { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Chất Liệu")]
        public string Materials { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Màu Sắc")]
        public string Color { get; set; }

        [ForeignKey("Room")]
        public int IdRoom { get; set; }
        public Room Room { get; set; }
    }
}