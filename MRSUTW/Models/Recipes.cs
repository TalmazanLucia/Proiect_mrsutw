using MRSUTW.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRSUTW.Models
{
    public class Recipes
    {
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public string Method { get; set; }
        public string Description { get; set; }
        public int Cook { get; set; }
        public int Prep { get; set; }
        public int kcal { get; set; }
        public int fat { get; set; }
        public int carbs { get; set; }
        public int protein { get; set; }
    }
}