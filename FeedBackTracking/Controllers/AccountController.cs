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
    public class AccountController : Controller
    {
        Get_role gt = new Get_role();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginData ld)
        {
            string check = "";
            string st = "";
            if(ModelState.IsValid)
            {
                bool IsAuthorized = WebSecurity.Login(ld.username, ld.password);
                if(IsAuthorized)
                {
                       string requesturl = Request.QueryString["RequestUrl"];
                       if (requesturl == null)
                       {
                           check = gt.getrolebyusername(ld.username);
                           st = gt.getmanaging_agentstatus(ld.username);
                           if (check == "super admin")
                           {
                               Session["username"] = ld.username;
                               Session["Role"] = check;
                               Response.Redirect("~/SuperAdmin/AdminDashboard");
                               
                           }
                           else if(check=="managing agent")
                           {
                               if (st == "Active")
                               {
                                   Response.Redirect("~/Managing_agent/ManagingDashboard");
                               }
                               else
                               {
                                   ViewBag.msg = "Your Account is DeActivated";
                                   return View();
                               }
                           }
                           else
                           {
                               return View();
                           }
                       }
                       else
                       {
                           Response.Redirect(requesturl);
                       }
                    
                }
            }
            return View();
        }

        public ActionResult Forgetpassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Forgetpassword(ForgetpassData ft)
        {
            //check user existance
            var user = Membership.GetUser(ft.Username);
            if (user == null)
            {
                TempData["Message"] = "User Not exist.";
            }
            else
            {
                //generate password token
                var token = WebSecurity.GeneratePasswordResetToken(ft.Username);
                //create url with above token
                var resetLink = "<a href='" + Url.Action("ResetPassword", "Account", new { @un = ft.Username, @rt = token }, "http") + "'>Reset Password</a>";
                //get user emailid
                string emailid=Managing_Agent.get_email(ft.Username);
                string subject = "Password Reset Token";
                string body = "<b>Please find the Password Reset Token</b><br/>" + resetLink; //edit it
                try
                {
                    #region
                    System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
                    client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    client.EnableSsl = true;
                    client.Host = "smtp.gmail.com";
                    client.Port = 587;


                    System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("kartik.starex.1234@gmail.com", "kartikbhambukumar");
                    client.UseDefaultCredentials = false;
                    client.Credentials = credentials;

                    System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
                    msg.From = new MailAddress("kartik.starex.1234@gmail.com");
                    msg.To.Add(new MailAddress(emailid));

                    msg.Subject = subject;
                    msg.IsBodyHtml = true;
                    msg.Body = body;

                    client.Send(msg);
                    #endregion
                    
                    TempData["Message"] = "Mail Sent.";
                }
                catch (Exception ex)
                {
                    TempData["Message"] = "Error occured while sending email." + ex.Message;
                }
               
                TempData["Message"] = resetLink;
              }

            return View();
        }
        public ActionResult ResetPassword(string un, string rt)
        {
            Resetpass p = new Resetpass();
            p.usern = un;
            p.token = rt;
            return View(p);
        }

        [HttpPost]
        public ActionResult ResetPassword(Resetpass ps)
        {
           
            //TODO: Check the un and rt matching and then perform following
            //get userid user table from username
            int id1=Managing_Agent.get_userid(ps.usern);
            //get userid  token from membershiptable from token
            int id2 = Managing_Agent.get_userid_bytoken(ps.token);

            if (id1 == id2)
            {
                //generate random password
                string newpass = ps.newpassword;
                //reset password
                bool response = WebSecurity.ResetPassword(ps.token, newpass);
                if (response == true)
                {
                    //get user emailid to send password
                    var emailid =Managing_Agent.get_email(ps.usern);
                    //send email
                    string subject = "New Password";
                    string body = "<b>Please find the New Password</b><br/>" + newpass; //edit it
                    try
                    {
                        #region
                        System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
                        client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                        client.EnableSsl = true;
                        client.Host = "smtp.gmail.com";
                        client.Port = 587;


                        System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("kartik.starex.1234@gmail.com", "kartikbhambukumar");
                        client.UseDefaultCredentials = false;
                        client.Credentials = credentials;

                        System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
                        msg.From = new MailAddress("kartik.starex.1234@gmail.com");
                        msg.To.Add(new MailAddress(emailid));

                        msg.Subject = subject;
                        msg.IsBodyHtml = true;
                        msg.Body = body;

                        client.Send(msg);
                        #endregion

                        TempData["Message"] = "Mail Sent.";
                       
                    }
                    catch (Exception ex)
                    {
                        TempData["Message"] = "Error occured while sending email." + ex.Message;
                    }

                    //display message
                    TempData["Message"] = "Success! Check email we sent";
                }
                else
                {
                    TempData["Message"] = "Hey, avoid random request on this page.";
                }
            }
            else
            {
                TempData["Message"] = "Username and token not maching.";
            }

            return View();
           
        }
       
	}
}