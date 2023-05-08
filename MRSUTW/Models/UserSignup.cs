using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRSUTW.Models
{
     public class UserSignup
     {
          public string Email { get; set; }
          public string Username { get; set; }
          public string Password1 { get; set; }
          public string Password2 { get; set; }
          public string LoginIp { get; set; }
          public DateTime LoginDateTime { get; set; }
     }
}