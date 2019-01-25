using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace FeedBackTracking.Models
{
    public class ForgetpassData
    {
        [Required(ErrorMessage="Field is required")]
        public string Username { get; set; }
    }
}