using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models
{
    public class Products批次更新ViewModel
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        [Range(1, 9999)]
        public Nullable<decimal> Price { get; set; }

        [Required]
        [Range(0, 9999)]
        public Nullable<decimal> Stock { get; set; }
    }
}