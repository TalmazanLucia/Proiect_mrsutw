using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MRSUTW.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DeleteCookie()
        {
               if (Request.Cookies["MRSUTW"] != null)
               {
                    var c = new HttpCookie("MRSUTW");
                    c.Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies.Add(c);

                    return RedirectToAction("Index", "SignIn");
               }

               return View("Index");
        }
    }
}