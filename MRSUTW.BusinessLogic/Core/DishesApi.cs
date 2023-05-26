using MRSUTW.BusinessLogic.DBModel;
using MRSUTW.Domain.Entities.Dishes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRSUTW.BusinessLogic.Core
{
    internal class DishesApi
    {
        internal List<DishesData> GetDishesAction()
        {
            List<DishesData> dishesData = new List<DishesData>();

            using (var db = new UserContext())
            {
                var dishesList = db.Dishes.ToList();

                foreach (var dish in dishesList)
                {
                    var dishData = new DishesData
                    {
                        ID = dish.Id,
                        Name = dish.Name,
                        Description = dish.Description,
                    };

                    dishesData.Add(dishData);
                }
            }

            return dishesData;
        }

        internal DishesData GetDishesByIdAction(int id)
        {
            DishesData dishesData = new DishesData();

            using (var db = new UserContext())
            {
                var dishesList = db.Dishes.ToList();

                foreach (var dish in dishesList)
                {
                    if (dish.Id == id)
                    {
                        var dishData = new DishesData
                        {
                            ID = dish.Id,
                            Name = dish.Name,
                            Description = dish.Description,
                        };

                        dishesData = dishData;
                    }
                }
            }

            return dishesData;
        }
    }
}