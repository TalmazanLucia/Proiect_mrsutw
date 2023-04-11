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
        // GET: SignUp
        public ActionResult Index()
        {
               User u = new User();
               u.Username = "admin";
               u.Email= "admin@gmail.com";
               u.Password = "admin";

               return View();
        }
    }
}