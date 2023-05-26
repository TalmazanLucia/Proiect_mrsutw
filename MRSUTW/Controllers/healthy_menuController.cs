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
                cfg.CreateMap<DishesData, ProductsModel>();
            });

            IMapper mapper = config.CreateMapper();

            List<DishesData> dishesDataList = _dishes.GetDishes();
            List<ProductsModel> dishes = dishesDataList.Select(usersProfileData => mapper.Map<ProductsModel>(dishesDataList)).ToList();

            ProductsModel p = new ProductsModel();
            p.Username = "Customer";
            p.Menus = new List<string> { "Meniu #1", "Meniu #2", "Meniu #3", "Meniu #4", "Meniu #5" };


            return View(p);
        }
    }
}
