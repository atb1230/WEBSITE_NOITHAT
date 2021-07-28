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
        [ForeignKey("TypeProduct")]
        [Display(Name = "Loại Sản Phẩm")]
        public string IdTypeProduct { get; set; }
        public TypeProduct TypeProduct { get; set; }

        [Key]
        [Required]
        [StringLength(255)]
        public string IdProduct { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name ="Tên Sản Phẩm")]
        public string NameProduct { get; set; }

        [ForeignKey("Status")]
        [Display(Name = "Trạng Thái")]
        public int IdStatus { get; set; }
        public Status Status { get; set; }

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

        [Required]
        [Display(Name ="Giá Tiền")]
        public double Price { get; set; }

        [ForeignKey("Room")]
        public int IdRoom { get; set; }
        public Room Room { get; set; }

        [Required]
        [Display(Name ="Hình Ảnh")]
        public string Picture1 { get; set; }

      
        [Display(Name ="Hình Ảnh 2")]
        public string Picture2 { get; set; }
       
        [Display(Name ="Hình Ảnh 3")]
        public string Picture3 { get; set; }
        //-------------------------------------------
        public Product()
        {
            Picture1 = "/Images/logo.png";
            Picture2 = "/Images/logo.png";
            Picture3 = "/Images/logo.png";
        }
        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload2 { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageUpload3 { get; set; }

    }
}