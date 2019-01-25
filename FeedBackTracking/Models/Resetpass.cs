using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace FeedBackTracking.Models
{
    public class Resetpass
    {
        [Required(ErrorMessage="Field is Required")]
        public string newpassword { set; get; }

        [Required(ErrorMessage = "Field is Required")]
        [Compare("newpassword", ErrorMessage = "Password Not Matched")]
        public string confirmpassword { set; get; }

        public string usern { set; get; }

        public string token { set; get; }
    }
}