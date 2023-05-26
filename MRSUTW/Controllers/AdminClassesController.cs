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
    public class AdminClassesController : Controller
    {
          private IActivities _activities;
          private ISession _session;

          public AdminClassesController()
          {
               var bl = new BusinessLogic.BussinesLogic();
               _activities = bl.GetActivitiesBL();
               _session = bl.GetSessionBL();
          }
        // GET: AdminClasses
        public ActionResult Index()
        {
               var userCookie = Request.Cookies["MRSUTW"];
               if (userCookie == null) { return RedirectToAction("Index", "Home"); }

               if (_session.GetIsAdminTypeByCookie(userCookie.Value))
               {
                    var config = new MapperConfiguration(cfg => {
                         cfg.CreateMap<Table_Activities, ActivitiesModel>();
                    });

                    IMapper mapper = config.CreateMapper();

                    List<Table_Activities> activitiesList = _activities.GetActivities();
                    List<ActivitiesModel> activities = activitiesList.Select(activitiy => mapper.Map<ActivitiesModel>(activitiy)).ToList();

                    return View(activities);
               }
               else
               {
                    return RedirectToAction("Index", "Home");
               }
        }

          public ActionResult Delete(int id)
          {
               var userCookie = Request.Cookies["MRSUTW"];
               if (userCookie == null) { return RedirectToAction("Index", "SignIn"); }

               _activities.DeleteActivityById(id);

               var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<Table_Activities, ActivitiesModel>();
               });

               IMapper mapper = config.CreateMapper();

               List<Table_Activities> activitiesList = _activities.GetActivities();
               List<ActivitiesModel> activities = activitiesList.Select(activitiy => mapper.Map<ActivitiesModel>(activitiy)).ToList();


               return View("Index", activities);
          }
     }
}