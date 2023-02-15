using bekle.Models;
using bekle.Services.Bussines;
using bekle.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace bekle.Controllers
{
    public class loginController : Controller
    {
        // GET: login
        public ActionResult Index()
        {
            return View("Login");

        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Account", "Account");
        }
        public ActionResult Login(UserAccount userModel)
        {
            SecurityService securityService = new SecurityService();
            Boolean success = securityService.Authenticate(userModel);

            if (success)
            {
                return View("LoginSuccess", userModel);

            }
            else
            {
                return View("LoginFailure");

            }
        }
        [HttpGet]
        public ActionResult Edit()
        {

            UserAccount u = new UserAccount();


            return View();
        }
        public ActionResult Edit (UserAccount useraccount)


        {
            SecurityService securityService = new SecurityService();
            Boolean success = securityService.register (useraccount);

            if (success)
            {
                return View("~/Views/login/Login.cshtml");
            }

            return View("Edit");


        }
    }



    }

