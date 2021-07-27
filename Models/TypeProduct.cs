using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace demo_02.Models
{
    public class TypeProduct
    {
        [Key]
        [StringLength(255)]
        public string IdTypeProduct { get; set; }

        [StringLength(255)]
        public string NameTypeProdcut { get; set; }

        public ICollection<Product> Product { get; set; }
    }
}