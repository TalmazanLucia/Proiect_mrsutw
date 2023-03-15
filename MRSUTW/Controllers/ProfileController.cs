using MRSUTW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MRSUTW.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Index()
        {
            User user = new User();
            user.Username = "admin";
            user.Email= "admin@gmail.com";

            return View(user);
        }
    }
}