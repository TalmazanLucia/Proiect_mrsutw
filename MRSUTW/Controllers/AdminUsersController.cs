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
     public class AdminUsersController : Controller
     {
          private ISession _session;

          public AdminUsersController()
          {
               var bl = new BusinessLogic.BussinesLogic();
               _session = bl.GetSessionBL();
          }

          // GET: AdminUsers
          public ActionResult Index()
          {
               var userCookie = Request.Cookies["MRSUTW"];
               if (userCookie == null) { return RedirectToAction("Index", "Home"); }

               if (_session.GetIsAdminTypeByCookie(userCookie.Value))
               {
                    var config = new MapperConfiguration(cfg => {
                         cfg.CreateMap<UProfileData, User>();
                    });

                    IMapper mapper = config.CreateMapper();

                    List<UProfileData> usersProfileDataList = _session.GetUsers();
                    List<User> users = usersProfileDataList.Select(usersProfileData => mapper.Map<User>(usersProfileData)).ToList();

                    return View(users);
               }
               else
               {
                    return RedirectToAction("Index", "Home");
               }
          }
     }
}