using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OnlineMobileShop.Entity
{
    public class Mobile
    {
        [Key]
        public int MobileID { get; set; }

        public int BrandID { get; set; }
        [NotMapped]
        public Brand Brand { get; set; }
        public string Model { get; set; }
        public int Battery { get; set; }
        public int RAM { get; set; }
        public int ROM { get; set; }
        public int Price { get; set; } 
    }
}
