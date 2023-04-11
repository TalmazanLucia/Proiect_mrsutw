using MRSUTW.BusinessLogic.Interfaces;
using MRSUTW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MRSUTW.BusinessLogic;
using MRSUTW.Domain.Entities.User;

namespace MRSUTW.Controllers
{
    public class SignInController : Controller
    {
          private readonly ISession _session;

          public SignInController()
          {
               var bl = new BusinessLogic.BussinesLogic();
               _session = bl.GetSessionBL();
          }
          // GET: SignIn
          public ActionResult Index()
        {
            User u = new User();
            u.Username = "admin";
            u.Password = "admin";

            return View(u);
        }

          [HttpPost]
          public ActionResult Index(User login)
          {
               if (true)
               {
                    ULoginData data = new ULoginData
                    {
                         Credential = login.Username,
                         Password = login.Password,
                         LoginIp = Request.UserHostAddress,
                         LoginDateTime = DateTime.Now,
                    };

                    var userLogin = _session.UserLogin(data);
                    if (userLogin.Status)
                    {
                         return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                         ModelState.AddModelError("", userLogin.StatusMsg);
                         return View();
                    }
               }

               return View();
          }
    }
}