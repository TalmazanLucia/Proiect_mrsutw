using MRSUTW.BusinessLogic.DBModel;
using MRSUTW.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRSUTW.BusinessLogic.Core
{
     internal class ActivitiesApi
     {
          public List<Table_Activities> GetActivitiesAction()
          {
               using(var db = new UserContext())
               {
                    return db.Activities.ToList();
               }
          }

          public void DeleteActivityByIdAction(int id)
          {
               using (var db = new UserContext())
               {
                    var activity = db.Activities.Find(id);
                    if (activity != null)
                    {
                         db.Activities.Remove(activity);
                         db.SaveChanges();
                    }
               }
          }
     }
}
