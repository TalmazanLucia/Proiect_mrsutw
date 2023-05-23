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

               var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<UProfileData, User>();
               });

               IMapper mapper = config.CreateMapper();

               List<UProfileData> usersProfileDataList = _session.GetTrainers();
               List<User> users = usersProfileDataList.Select(usersProfileData => mapper.Map<User>(usersProfileData)).ToList();

               return View(users);
          }
     }
}
