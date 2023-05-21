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
     public class TrainersController : Controller
     {
          private ISession _session;

          public TrainersController()
          {
               var bl = new BusinessLogic.BussinesLogic();
               _session = bl.GetSessionBL();
          }
          // GET: Trainers
          public ActionResult Index()
          {
               var userCookie = Request.Cookies["MRSUTW"];
               if (userCookie == null) { return RedirectToAction("Index", "Home"); }

               var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<UTrainersData, TrainersModel>();
               });

               IMapper mapper = config.CreateMapper();

               TrainersModel u = mapper.Map<TrainersModel>(_session.GetProfileByCookie(userCookie.Value));


               return View(u);
          }

          [ActionName("Trainer")]
          public ActionResult Index(int id)
          {
               var userCookie = Request.Cookies["MRSUTW"];
               if (userCookie == null) { return RedirectToAction("Index", "Home"); }

               var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<UTrainersData, TrainersModel>();
               });

               IMapper mapper = config.CreateMapper();

               TrainersModel u = mapper.Map<TrainersModel>(_session.GetTrainerById(id));

               return View("Index", u);
          }

          [HttpPost]
          public ActionResult Index(TrainersModel data)
          {
               _session.UpdateTrainer(new UTrainersData
               {
                    ID = data.ID,
                    Username = data.Username,
                    Email = data.Email,
                    Identity = data.Identity,
                    Description = data.Description,
                    Age = data.Age,
                    Weight = data.Weight,
                    Height = data.Height,
               });

               return View(data);
          }

     }
}