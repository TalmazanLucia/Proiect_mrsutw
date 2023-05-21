﻿using MRSUTW.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRSUTW.Domain.Entities.User
{
     public class UTrainersData
     {
          public int ID { get; set; }
          public string Username { get; set; }
          public string Email { get; set; }
          public string Password { get; set; }
          public DateTime Registred { get; set; }
          public string Identity { get; set; }
          public string Description { get; set; }
          public int Age { get; set; }
          public int Weight { get; set; }
          public int Height { get; set; }
          public URole Role { get; set; }

     }
}
