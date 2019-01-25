using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace FeedBackTracking.Models
{
    public class LoginData
    {
        [Required(ErrorMessage="Field is required")]
        [Display(Name = "User Name")]
        public string username { get; set; }

         [Required(ErrorMessage = "Field is required")]
        [DataType(DataType.Password)]
        [Display(Name = "password")]
        public string password { get; set; }
    }
}