﻿using MRSUTW.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRSUTW.BusinessLogic
{
    public class BussinesLogic
    {
          public ISession GetSessionBL()
          {
               return new SessionBL();
          }
    }
}