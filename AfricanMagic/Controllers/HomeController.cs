using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AfricanMagic.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your application contact page.";

            return View();
        }

        public ActionResult CheckOut()
        {
            ViewBag.Message = "Your checkout page.";

            return View();
        }


        public ActionResult Cart()
        {
            ViewBag.Message = "Your Cart page.";

            return View();
        }

        public ActionResult ProductInfo()
        {
            ViewBag.Message = "Your Product Info page.";

            return View();
        }

        public ActionResult MensSection()
        {
            ViewBag.Message = "Your Mens page.";

            return View();
        }

        public ActionResult WomensSection()
        {
            ViewBag.Message = "Your Womens page.";

            return View();
        }

        public ActionResult KidsSection()
        {
            ViewBag.Message = "Your Kids page.";

            return View();
        }

    }
}