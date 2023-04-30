using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MRSUTW.Domain.Entities.User;

namespace MRSUTW.BusinessLogic.DBModel.Seed
{
     class UserContext : DbContext 
     {
          public UserContext() :
               base("name=MRSUTW") //connectionstring name define in web.config
          { 
          }
          public virtual DbSet<UDbTable> Users { get; set; }
     }
}
