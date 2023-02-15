using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bekle.Controllers
{
    public class HomeController : Controller
    {

        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Attacks";

            return View();
        }


        public String Login()
        {
            return "Test bro  ";

        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Account()
        {
            ViewBag.Message = "Your REGİSTER page.";

            return View();
        }








    }
}
