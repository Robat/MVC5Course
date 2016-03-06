using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models
{
    public class MemberViewModel
    {
        public int Id { get; set; }
        public String Name { get; set; }
        [Required(ErrorMessage = "please is ...")]
        public DateTime Birthday { get; set; }

    }
}