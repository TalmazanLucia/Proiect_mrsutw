﻿using MRSUTW.Domain.Entities.Appointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRSUTW.BusinessLogic.Interfaces
{
     public interface IAppointment
     {
          void Save(Appointment appointment);
     }
}
