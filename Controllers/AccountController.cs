using bekle.Models;
using bekle.Services.Bussines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bekle.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View("Register");

        }

        public ActionResult Account()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Account(UserAccount useraccount)


        {
            SecurityService securityService = new SecurityService();
            Boolean success = securityService.register(useraccount);

            if (success)
            {
                return View("~/Views/login/Login.cshtml");
            }

            return View("Account");


        }



    }
    


}
