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
               User u = new User();
               u.Username = "Lucia Talmazan";
               u.Email= "admin@gmail.com";
               u.Registred = "25 february 2023";
               u.Identity = "Female";
               u.Description = "Every day sport becomes more important than ever. Of course, we all notice the bad diet that many people follow now due to the lack of time. Fast food saturated with fats and carbohydrates has become one of the meals of our children as well as adults.";
               u.Age = 20;
               u.Weight = 50;
               u.Height = 170;
            

               return View(u);
        }
    }
}