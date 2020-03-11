using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineMobileShop.Entity;

namespace OnlineMobileShop.Respository
{
   public class BrandRepository
    {
        public void AddBrand(Entity.Brand brand)
        {
            using (DBContext context = new DBContext())
            {
                context.brand.Add(brand);
                context.SaveChanges();
            }
        }
    }
}
