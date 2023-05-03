using MRSUTW.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRSUTW.BusinessLogic.Core
{
     internal class UserApi
     {
          internal PostResponse UserLoginAction(ULoginData data)
          {
               return new PostResponse { Status = true };
          }

          internal PostResponse UserRegisterAction(ULoginData data)
          {
               return new PostResponse { Status = true };
          }

          internal UProfileData GetProfileAction()
          {
               UProfileData u = new UProfileData();
               u.Username = "Lucia Talmazan";
               u.Email = "admin@gmail.com";
               u.Registred = "25 february 2023";
               u.Identity = "Female";
               u.Description = "Every day sport becomes more important than ever. Of course, we all notice the bad diet that many people follow now due to the lack of time. Fast food saturated with fats and carbohydrates has become one of the meals of our children as well as adults.";
               u.Age = 20;
               u.Weight = 50;
               u.Height = 170;

               return u;
          }
          internal UTrainersData GetTrainersAction()
          {
               UTrainersData t = new UTrainersData();
               t.Username = "Arnold Bunicescu";
               t.Email = "arnold_trainer@gmail.com";
               t.Registred = "5 may 2023";
               t.Identity = "Male";
               t.Description = "Trainer for beginners, advanced, ";
               t.Age = 22;
               t.Weight = 86;
               t.Height = 196;

               return t;
          }    
     }
}
