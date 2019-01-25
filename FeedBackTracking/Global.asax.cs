using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using WebMatrix.WebData;

namespace FeedBackTracking
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            InitailizeAuthinticated();
           
        }
        private void InitailizeAuthinticated()
        {
            if(!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection("myconnection", "User", "UserId", "UserName", autoCreateTables: true);
                //WebSecurity.CreateUserAndAccount("admin", "admin123");
                //Roles.CreateRole("super admin");
                //Roles.CreateRole("managing admin");
                //Roles.CreateRole("Tenant");
                //Roles.CreateRole("LTC");
                //Roles.CreateRole("MCST Council member");
                //Roles.CreateRole("Incharge");
                //Roles.CreateRole("Builder");

                //Roles.AddUserToRole("admin", "super admin");

            }
        }
    }
}
