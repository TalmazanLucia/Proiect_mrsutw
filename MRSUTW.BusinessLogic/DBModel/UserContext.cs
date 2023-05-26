using MRSUTW.Domain.Entities.Dishes;
using MRSUTW.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRSUTW.BusinessLogic.DBModel
{
     public class UserContext : DbContext
     {
          public UserContext() :
               base("name=MRSUTW")
          { }

          public virtual DbSet<UDbTable> Users { get; set; }
          public virtual DbSet<SessionsDbTable> Sessions { get; set; }
          public virtual DbSet<Table_Activities> Activities { get; set; }
          public virtual DbSet<DishesDbTable> Dishes { get; set; }


    }
}
