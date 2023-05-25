using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MRSUTW.Models
{
    public class ActivitiesModel
    {
        // GET api/<controller>
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