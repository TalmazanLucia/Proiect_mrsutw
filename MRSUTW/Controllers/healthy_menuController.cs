using MRSUTW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MRSUTW.Controllers
{
    public class healthy_menuController : Controller
    {
        // GET: healthy_menu
        public ActionResult Index()
        {
            ProductsModel p = new ProductsModel();
            p.Username = "Customer";
            p.Menus = new List<string> {"Meniu #1", "Meniu #2", "Meniu #3", "Meniu #4", "Meniu #5"};

               
            return View(p);
        }
    }
}