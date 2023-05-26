using MRSUTW.BusinessLogic.Core;
using MRSUTW.BusinessLogic.Interfaces;
using MRSUTW.Domain.Entities.Dishes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRSUTW.BusinessLogic
{
    internal class DishesBL : DishesApi, IDishes
    {
        public List<DishesData> GetDishes()
        {
            return GetDishesAction();
        }

        public DishesData GetDishesById(int id)
        {
            return GetDishesByIdAction(id);
        }
    }
}

