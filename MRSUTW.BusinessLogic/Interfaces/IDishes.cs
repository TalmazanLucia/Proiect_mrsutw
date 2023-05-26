using MRSUTW.Domain.Entities.Dishes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRSUTW.BusinessLogic.Interfaces
{
    public interface IDishes
    {
        List<DishesData> GetDishes();
    }
}

