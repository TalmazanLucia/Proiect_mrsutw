using MRSUTW.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRSUTW.BusinessLogic.Interfaces
{
     public interface ISession
     {
          PostResponse UserLogin(ULoginData data);
     }
}
