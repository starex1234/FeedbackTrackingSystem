using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace FeedBackTracking.Models
{
    public class Managing_agent_Data
    {
       public int UserId { get; set; }

       [Display(Name="Company Name")]
       [Required(ErrorMessage="Field is required")]
        public string companyName { set; get; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Field is required")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
         @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + 
         @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",ErrorMessage="Please Enter Valid Email")]
        public string Email { set; get; }

         [Display(Name = "Phone Number")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Please Enter a Valid Mobile No.")]                        
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]        
        [Required(ErrorMessage = "Field is required")]
        public string phone_number {set;get;}

         [Display(Name = "Password")]
         [DataType(DataType.Password)]
         [Required(ErrorMessage = "Field is required")]
         public string password { set; get; }

         [Display(Name = "Contact Name")]
        [Required(ErrorMessage = "Field is required")]
        public string contact_name { set; get; }

         public string status_ { set; get; }
        

    }
    public class change_password
    {
        [Display(Name = "Old Password")]
        [Required(ErrorMessage = "Field is required")]
        public string oldpassword { set; get; }

        [Display(Name = "New Password")]
        [Required(ErrorMessage = "Field is required")]
        public string newpassword { set; get; }

        [Display(Name = "Confirm Password")]
        [Compare("newpassword", ErrorMessage = "Password Not Matched")]
        [Required(ErrorMessage = "Field is required")]
        public string confirmnewpassword { set; get; }
    }
}