using MRSUTW.BusinessLogic.Core;
using MRSUTW.BusinessLogic.Interfaces;
using MRSUTW.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MRSUTW.BusinessLogic
{
     internal class SessionBL : UserApi, ISession
     {
          public PostResponse UserLogin(ULoginData data)
          {
               return UserLoginAction(data);
          }
          public PostResponse UserRegister(USignupData data)
          {
               return UserRegisterAction(data);
          }
          public HttpCookie GenCookie(string loginCredential)
          {
               return Cookie(loginCredential);
          }
          public UProfileData GetProfileByCookie(string cookie)
          {
               return GetProfileByCookieAction(cookie);
          }
          public UProfileData GetProfileById(int id)
          {
               return GetProfileByIdAction(id);
          }
          public PostResponse UpdateProfile(UProfileData profile)
          {
               return UpdateProfileAction(profile);
          }
          public List<UProfileData> GetUsers()
          {
               return GetUsersAction();
          }
          public UTrainersData GetTrainers()
          {
               return GetTrainersAction();
          }
     }
}
