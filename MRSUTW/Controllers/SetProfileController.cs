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
     public class SetProfileController : Controller
     {
          private ISession _session;

          public SetProfileController()
          {
               var bl = new BusinessLogic.BussinesLogic();
               _session = bl.GetSessionBL();
          }

          // GET: SetProfile
          public ActionResult Index()
          {
               var userCookie = Request.Cookies["MRSUTW"];
               if (userCookie == null) { return RedirectToAction("Index", "Home"); }

               return View();
          }

          [HttpPost]
          public ActionResult Index(User data)
          {
               var userCookie = Request.Cookies["MRSUTW"];
               if (userCookie == null) { return RedirectToAction("Index", "Home"); }

               var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<UProfileData, User>();
               });

               IMapper mapper = config.CreateMapper();

               User u = mapper.Map<User>(_session.GetProfileByCookie(userCookie.Value));

               PostResponse response = _session.UpdateProfile(new UProfileData
               {
                    ID = u.ID,
                    Username = u.Username,
                    Identity = data.Identity,
                    Age = data.Age,
                    Description = data.Description,
                    Weight = data.Weight,
                    Height = data.Height,
                    Email = u.Email,
               });

               if (response.Status)
               {
                    return RedirectToAction("Index", "Home");
               }
               else
               {
                    return View();
               }
          }
     }
}