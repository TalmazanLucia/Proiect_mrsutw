using AutoMapper;
using MRSUTW.BusinessLogic.Interfaces;
using MRSUTW.Domain.Entities.User;
using MRSUTW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MRSUTW.Controllers
{
    public class AdminSalaController : Controller
    {
        private ISession _session;

        public AdminSalaController()
        {
            var bl = new BusinessLogic.BussinesLogic();
            _session = bl.GetSessionBL();
        }

        // GET: AdminUsers
        public ActionResult Index()
        {
            return View();
        }
    }
}