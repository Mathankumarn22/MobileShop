using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMobileShop.Entity
{
    class Category
    {
        [Key]
        public int CategoryID { get; set; } 
        public int BrandID { get; set; }
        public Brand Brand { get; set; }
        public string CategoryName { get; set; }
    }
}
