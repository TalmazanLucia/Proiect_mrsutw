using MRSUTW.BusinessLogic.Core;
using MRSUTW.BusinessLogic.Interfaces;
using MRSUTW.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRSUTW.BusinessLogic
{
     internal class ActivitiesBL : ActivitiesApi, IActivities
     {
          public List<Table_Activities> GetActivities()
          {
               return GetActivitiesAction();
          }

          public void DeleteActivityById(int id)
          {
               DeleteActivityByIdAction(id);
          }
     }
}
