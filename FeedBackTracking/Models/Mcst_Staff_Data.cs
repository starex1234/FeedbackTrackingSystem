using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace FeedBackTracking.Models
{
    public class Mcst_Staff_Data
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Field is required")]
        public string Name { get; set; }

        [Display(Name = "Email  Address")]
        [Required(ErrorMessage = "Field is required")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
        @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
        @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please Enter Valid Email")]
        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Field is required")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Please Enter a Valid Mobile No.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]   
        public string Phone_number { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Field is required")]
        public string Password { get; set; }

        [Display(Name = "Property")]
        [Required(ErrorMessage = "Field is required")]
        public string Property { get; set; }

        [Display(Name = "Role")]
        [Required(ErrorMessage = "Field is required")]
        public string Role { get; set; }

        [Display(Name = "Feedback Category")]
        [Required(ErrorMessage = "Field is required")]
        public string Feedback_Category { get; set; }
       
    }
    public class Tenant_data
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Field is required")]
        public string Name { get; set; }

        [Display(Name = "Email  Address")]
        [Required(ErrorMessage = "Field is required")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
        @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
        @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please Enter Valid Email")]
        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Field is required")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Please Enter a Valid Mobile No.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string Phone_number { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Field is required")]
        public string Password { get; set; }

        [Display(Name = "Unit Number")]
        [Required(ErrorMessage = "Field is required")]
        public string Unit_number { get; set; }

        [Display(Name = "Company Name")]
        [Required(ErrorMessage = "Field is required")]
        public string CompanyName{ get; set; }

        [Display(Name = "Property")]
        [Required(ErrorMessage = "Field is required")]
        public string Property { get; set; }

        [Display(Name = "MCST Number")]
        [Required(ErrorMessage = "Field is required")]
        public string MCST_Number { get; set; }

        [Display(Name = "MCST council member")]
        [Required(ErrorMessage = "Field is required")]
        public string MCST_council_member { get; set; }

    }

    public class Add_Property
    {

    }
    public class Add_Feedback_Category
    {
        [Required(ErrorMessage = "Field is required")]
        public string Name { get; set; }
        
    }
    public class Add_Location_Category
    {
        public string Is_Active { set; get; }
        public int Id { get; set; }
        [Required(ErrorMessage = "Field is required")]
        public string Name { get; set; }
    }
}