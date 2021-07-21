using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace demo_02.Models
{
    public class Room
    {
        [Key]
        public int IdRoom { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name ="Tên Phòng")]
        public string NameRoom { get; set; }

        public ICollection<Product> Product { get; set; }
    }
}