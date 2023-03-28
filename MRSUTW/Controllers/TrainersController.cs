using Microsoft.Ajax.Utilities;
using MRSUTW.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MRSUTW.Controllers
{
    public class TrainersController : Controller
    {
        // GET: Trainers
        public ActionResult Index()
        {
               TrainersModel t = new TrainersModel();

               t.Name = "Name";
               t.Description = "Description";
                     
            return View();
        }
    }
}