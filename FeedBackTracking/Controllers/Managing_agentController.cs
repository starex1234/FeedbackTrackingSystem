using FeedBackTracking.Models;
using FeedBackTracking.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FeedBackTracking.Controllers
{    [Authorize(Roles="managing agent")]
    public class Managing_agentController : Controller
    {
        public ActionResult ManagingDashboard()
        {
            return View();
        }

        public ActionResult Add_MCST()
        {
            return View();
        }

        public ActionResult MCST_Listing()
        {
            return View();
        }

        public ActionResult Add_Tenant()
        {
            return View();
        }
        public ActionResult Tenant_Listing()
        {
            return View();
        }

        public ActionResult Add_LTC()
        {
            return View();
        }

        public ActionResult LTC_Listing()
        {
            return View();
        }

        public ActionResult Add_FeedBack()
        {
            return View();
        }
        public ActionResult FeedBack_Listing()
        {
            return View();
        }

        public ActionResult Add_Category()
        {
            return View();
        }
        public ActionResult Category_Listing()
        {
            return View();
        }

        public ActionResult Add_Location()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add_Location(Add_Location_Category lc)
        {
            string user=Membership.GetUser().ToString();
            DateTime date = DateTime.Now;
            Managing_agent_repository.Add_Loc(lc, user, date);
            string message = "SUCCESS";
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });  
        }
       
        public JsonResult Get_Location(string id)
        {
            List<Add_Location_Category> lst = new List<Add_Location_Category>();
            lst = Managing_agent_repository.ReturnMList<Add_Location_Category>().ToList();
            return Json(lst, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Logout_M()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
	}
}