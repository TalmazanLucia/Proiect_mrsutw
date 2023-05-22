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
    public class Table_Activities
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string Prof { get; set; }
        public string Luni { get; set; }
        public string Marti { get; set; }
        public string Miercuri { get; set; }
        public string Joi { get; set; }
        public string Vineri { get; set; }
        public string Sambata { get; set; }
        public string Duminica { get; set; }
        public string LoculDesfasurarii { get; set; }
    }
}
