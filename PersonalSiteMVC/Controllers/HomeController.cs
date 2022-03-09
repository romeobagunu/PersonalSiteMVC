using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using PersonalSiteMVC.Models;
//added for Access to ContactViewModel.

using System.Net.Mail;
//Added for access to MailMessage.

using System.Configuration;
//Added for access to the config.

using System.Net;
//Added for access to NetworkCredential.

namespace PersonalSiteMVC.Controllers
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

        public ActionResult Resume()
        {
            return View();
        }

        public ActionResult Links()
        {
            return View();
        }

        public ActionResult Portfolio()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactViewModel cvm)
        {
            if (!ModelState.IsValid)
            {
                return View(cvm);
            }

            string message = $"{cvm.Name} has sent you the following message:<br />" +
                $"Subject: <strong>{cvm.Subject}</strong><br />" +
                $"{cvm.Message}<br />" +
                $"Please reply to {cvm.Email} at your earliest convenience.";

            MailMessage mm = new MailMessage(
                //FROM
                ConfigurationManager.AppSettings["EmailUser"].ToString(),
                //TO
                ConfigurationManager.AppSettings["EmailTo"].ToString(),
                //SUBJECT
                cvm.Subject,
                //BODY
                message);

            //Allows HTML tags in the message.
            mm.IsBodyHtml = true;

            //Designates the message as high priority.
            mm.Priority = MailPriority.High;

            //Adds the email to the reply.
            mm.ReplyToList.Add(cvm.Email);

            //Mail Client.
            SmtpClient client = new SmtpClient(ConfigurationManager.AppSettings["EmailClient"].ToString());

            //Configures credentials for mail client using config.
            client.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["EmailUser"].ToString(),
                ConfigurationManager.AppSettings["EmailPass"].ToString());

            try
            {
                //Send email
                client.Send(mm);
            }
            catch (Exception ex)
            {
                //Log error in the ViewBag
                ViewBag.CustomerMessage = $"We're sorry. Your request could not be completed at this time." +
                    $"Please try again later! <br />" +
                    $"Error Message:<br />" +
                    $"{ex.StackTrace}";
                return View(cvm);
            }

            return View("EmailConfirmation", cvm);
        }//end POST Contact

    }//end Controller
}//end namespace