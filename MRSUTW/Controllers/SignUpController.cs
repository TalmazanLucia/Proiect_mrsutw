﻿using MRSUTW.BusinessLogic.Interfaces;
using MRSUTW.Domain.Entities.User;
using MRSUTW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MRSUTW.Controllers
{
     public class SignUpController : Controller
     {
          private ISession _session;
          public SignUpController()
          {
               var bl = new BusinessLogic.BussinesLogic();
               _session = bl.GetSessionBL();
          }
          // GET: SignUp
          public ActionResult Index()
          {
               return View();
          }
          [HttpPost]
          public ActionResult Index(UserSignup signup)
          {
               if (ModelState.IsValid)
               {
                    USignupData data = new USignupData
                    {
                         Username = signup.Username,
                         Email = signup.Email,
                         Password1 = signup.Password1,
                         Password2 = signup.Password2,
                         LoginIp = Request.UserHostAddress,
                         LoginDateTime = DateTime.Now,
                    };

                    var userRegister = _session.UserRegister(data);
                    if (userRegister.Status)
                    {
                         return RedirectToAction("Index", "SignIn");
                    }
                    else
                    {
                         ModelState.AddModelError("", userRegister.StatusMsg);
                         return View();
                    }
               }

               return View();
          }
     }
}