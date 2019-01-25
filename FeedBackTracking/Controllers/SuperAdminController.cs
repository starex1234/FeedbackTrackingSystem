using FeedBackTracking.Models;
using FeedBackTracking.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace FeedBackTracking.Controllers
{
    [Authorize(Roles="super admin")]
    public class SuperAdminController : Controller
    {
        Managing_Agent mg = new Managing_Agent();
        public ActionResult AdminDashboard()
        {
            return View(Managing_Agent.ReturnMList<Managing_agent_Data>());
        }

        
        public ActionResult Addagent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Addagent(Managing_agent_Data md)
        {
            if(ModelState.IsValid)
            {

                bool IsUserExist= WebSecurity.UserExists(md.Email);
                if(IsUserExist)
                {
                    ModelState.AddModelError("UserName", "UserName Already Exist");
                }
                else
                {
                    var user = (string)Session["username"].ToString();
                    WebSecurity.CreateUserAndAccount(md.Email, md.password, new
                    {
                        CompanyName = md.companyName,
                        Phone_number = md.phone_number,
                        Contact_name = md.contact_name,
                        Email=md.Email,
                        Status_="Active",
                        Created_By=user,
                        Created_On=DateTime.Now
                    });
                    Roles.AddUserToRole(md.Email, "managing agent");
                    #region
                    MailMessage mail = new MailMessage();
                    mail.To.Add(md.Email);
                    mail.From = new System.Net.Mail.MailAddress("kartik.starex.1234@gmail.com");
                    mail.Subject = "Account created";
                    mail.Body = "Dear User your account has been created successfully for the role of Managing Agent And your UserName is "+md.Email+" and Password is "+md.password; 


                    System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential("kartik.starex.1234@gmail.com","");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);

                    #endregion
                    return RedirectToAction("AdminDashboard", "SuperAdmin");
                }
            }
            return View();
        }
        

        
        public ActionResult Edit(int id)
        {
            return View(Managing_Agent.get_managingById(id));
        }

        [HttpPost]
        public ActionResult Edit(Managing_agent_Data md,int id)
        {
             string user = (string)Session["username"].ToString();
            DateTime date = DateTime.Now;
            Managing_Agent.Update_Managing_Agent(md, user, date ,id);
            return RedirectToAction("AdminDashboard");
        }

        public ActionResult Delete(int id)
        {
            Managing_Agent.Delete_managing_agent(id);
            return RedirectToAction("AdminDashboard");
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
        public ActionResult Changepassword()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Changepassword(change_password ch)
        {
            if (ModelState.IsValid)
            {
                //string password="";
                string user = Membership.GetUser().ToString();
                string token = WebSecurity.GeneratePasswordResetToken(user);
                WebSecurity.ResetPassword(token, ch.newpassword);
                return RedirectToAction("AdminDashboard");
                //MembershipUser muser = Membership.GetUser(user);
                //string resetpassword = muser.ResetPassword();
                //muser.ChangePassword(resetpassword, ch.newpassword);
                //int userid=WebSecurity.GetUserId(user);

                //if (password == ch.oldpassword)
                //{
                //    string token = WebSecurity.GeneratePasswordResetToken(user);
                //    WebSecurity.ResetPassword(user, ch.newpassword);
                //}
            }
            return View();
        }
	}
}