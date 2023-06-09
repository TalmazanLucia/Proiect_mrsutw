using AutoMapper;
using MRSUTW.BusinessLogic.Interfaces;
using MRSUTW.Domain.Entities.Appointment;
using MRSUTW.Domain.Entities.User;
using MRSUTW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MRSUTW.Controllers
{
     public class AppointmentController : Controller
     {
          private ISession _session;
          private IAppointment _appointment;

          public AppointmentController()
          {
               var bl = new BusinessLogic.BussinesLogic();
               _session = bl.GetSessionBL();
               _appointment = bl.GetAppointmentBL();
          }

          public ActionResult Index()
          {
               return View();
          }

          [HttpPost]
          public ActionResult Save(string ora)
          {
               var userCookie = Request.Cookies["MRSUTW"];
               if (userCookie == null) { return RedirectToAction("Index", "Home"); }

               var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<UProfileData, User>();
               });

               IMapper mapper = config.CreateMapper();

               User u = mapper.Map<User>(_session.GetProfileByCookie(userCookie.Value));
               Appointment appointment = new Appointment()
               {
                    Email = u.Email,
                    Time = ora,
               };

               _appointment.Save(appointment);


               return Json(new { redirectUrl = Url.Action("Index", "Sala") });
          }
     }
}