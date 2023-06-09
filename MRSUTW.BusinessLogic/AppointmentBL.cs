using MRSUTW.BusinessLogic.Core;
using MRSUTW.BusinessLogic.Interfaces;
using MRSUTW.Domain.Entities.Appointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRSUTW.BusinessLogic
{
     public class AppointmentBL : AppointmentApi, IAppointment
     {
          public void Save(Appointment appointment)
          {
               SaveAction(appointment);
          }
     }
}
