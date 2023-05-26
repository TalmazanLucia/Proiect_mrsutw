using AutoMapper;
using MRSUTW.BusinessLogic.Interfaces;
using MRSUTW.Domain.Entities.Dishes;
using MRSUTW.Domain.Entities.User;
using MRSUTW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MRSUTW.Controllers
{
    public class healthy_menuController : Controller
    {
        private IDishes _dishes;
        public healthy_menuController()
        {

            var bl = new BusinessLogic.BussinesLogic();
            _dishes = bl.GetDishesBL();
        }
        // GET: healthy_menu
        public ActionResult Index()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<DishesData, Dish>();
            });

            IMapper mapper = config.CreateMapper();

            List<DishesData> usersProfileDataList = _dishes.GetDishes();
            List<Dish> dishes = usersProfileDataList.Select(usersProfileData => mapper.Map<Dish>(usersProfileData)).ToList();

            return View(dishes);
        }
    }
}