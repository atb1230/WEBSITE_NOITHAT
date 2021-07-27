using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace demo_02.Models
{
    public class Status
    {
        [Key]
        public int IdStatus { get; set; }

        [StringLength(255)]
        public string NameStatus { get; set; }

        public ICollection<Product> Product { get; set; }
    }
}