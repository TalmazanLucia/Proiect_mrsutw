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
    public class ProfileController : Controller
    {
          private ISession _session;

          public ProfileController()
          {
               var bl = new BusinessLogic.BussinesLogic();
               _session = bl.GetSessionBL();
          }
          // GET: Profile
          public ActionResult Index()
          {
               var userCookie = Request.Cookies["MRSUTW"];
               if (userCookie == null) { return RedirectToAction("Index", "Home"); }

               var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<UProfileData, User>();
               });

               IMapper mapper = config.CreateMapper();

               User u = mapper.Map<User>(_session.GetProfileByCookie(userCookie.Value));


               return View(u);
          }
     }
}