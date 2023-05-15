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
    public class AdminHomeController : Controller
    {
          private ISession _session;

          public AdminHomeController()
          {
               var bl = new BusinessLogic.BussinesLogic();
               _session = bl.GetSessionBL();
          }
          // GET: AdminHome
          public ActionResult Index()
          {
               var userCookie = Request.Cookies["MRSUTW"];
               if (userCookie == null) { return RedirectToAction("Index", "Home"); }

               var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<UProfileData, User>();
               });

               IMapper mapper = config.CreateMapper();
               AdminHomeData data = new AdminHomeData();

               List<UProfileData> usersProfileDataList = _session.GetUsers();
               data.Users = usersProfileDataList.Select(usersProfileData => mapper.Map<User>(usersProfileData)).ToList();

               return View(data);
          }
    }
}