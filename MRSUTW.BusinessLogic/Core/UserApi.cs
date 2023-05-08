﻿using MRSUTW.BusinessLogic.DBModel;
using MRSUTW.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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

          internal PostResponse UserRegisterAction(USignupData data)
          {
               UDbTable result;
               if (data.Password1 == null || data.Email == null)
               {
                    return new PostResponse { Status = false, StatusMsg = "Complet all fields" };
               }

               if (data.Password1 != data.Password2)
               {
                    return new PostResponse { Status = false, StatusMsg = "The Passwords don't match" };
               }

               if (data.Password1.Length < 8)
               {
                    return new PostResponse { Status = false, StatusMsg = "Password min 8 characters" };
               }

               if (data.Username.Length < 5)
               {
                    return new PostResponse { Status = false, StatusMsg = "Username min 5 characters" };
               }


               result = new UDbTable
               {
                    Username = data.Username,
                    Password = data.Password1,
                    Email = data.Email,
                    LastLogin = data.LoginDateTime,
                    LasIp = data.LoginIp,
               };

               using (var db = new UserContext())
               {
                    db.Users.Add(result);
                    db.SaveChanges();
 
               }

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
