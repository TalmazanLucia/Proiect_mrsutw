using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MRSUTW.Domain.Enums;

namespace MRSUTW.Domain.Entities.User
{
    public class DbAppointments
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Persona { get; set; }
        public string Trainer { get; set; }
        public DateTime AppointDT { get; set; }
    }
}
