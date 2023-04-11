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
     }
}
