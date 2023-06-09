using MRSUTW.BusinessLogic.DBModel;
using MRSUTW.Domain.Entities.Appointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRSUTW.BusinessLogic.Core
{
     public class AppointmentApi
     {
          public void SaveAction(Appointment appointment)
          {
               AppointmentDb data = new AppointmentDb()
               {
                    Id = appointment.Id,
                    Email = appointment.Email,
                    Time = appointment.Time,
               };

               using (var db = new UserContext())
               {
                    db.Appointments.Add(data);
                    db.SaveChanges();
               }
          }
     }
}
