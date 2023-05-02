﻿using MRSUTW.BusinessLogic.Core;
using MRSUTW.BusinessLogic.Interfaces;
using MRSUTW.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRSUTW.BusinessLogic
{
     internal class SessionBL : UserApi, ISession
     {
          public PostResponse UserLogin(ULoginData data)
          {
               return UserLoginAction(data);
          }
          public PostResponse UserRegister(ULoginData data)
          {
               return UserRegisterAction(data);
          }
          public UProfileData GetProfile()
          {
               return GetProfileAction();
          }

          public UTrainersData  GetTrainers()
          {
               return GetTrainersAction();
          }
     }
}
