using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using PersonalSiteMVC.Models;
//added for Access to ContactViewModel

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

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult (ContactViewModel cvm)
        {
            return View(cvm);
        }

    }
}