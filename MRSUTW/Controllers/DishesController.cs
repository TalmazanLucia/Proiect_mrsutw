using AutoMapper;
using MRSUTW.BusinessLogic.Interfaces;
using MRSUTW.Domain.Entities.Dishes;
using MRSUTW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MRSUTW.Controllers
{
    public class DishesController : Controller
    {
        private IDishes _dishes;

        public DishesController()
        {
            var bl = new BusinessLogic.BussinesLogic();
            _dishes = bl.GetDishesBL();
        }
        // GET: DishItem
        public ActionResult Index(int id)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<DishesData, Dish>();
            });

            IMapper mapper = config.CreateMapper();

            Dish u = mapper.Map<Dish>(_dishes.GetDishesById(id));

            return View(u);
        }
    }
}