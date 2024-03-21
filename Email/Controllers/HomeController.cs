using Email.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Email.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(Gmail gmail)
        {
            try
            {
                string toEmail = "najeebbrohi9477@gmail.com";
                MailMessage mm = new MailMessage();
                mm.To.Add(toEmail);
                mm.From = new MailAddress(gmail.Email);
                mm.Subject = gmail.Subject;
                mm.Body = $"From: {gmail.Name} ({gmail.Email}) \n\n {gmail.Message}";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("najeebbrohi9477@gmail.com", "lotn kimm znro yzcg");
                smtp.Port = 587;

                ViewBag.Msg = "Your email has been sent successfully";
                try
                {
                    smtp.Send(mm);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = $"Email Eorror : {ex.Message}";
            }
            return View();
        }
    }
}