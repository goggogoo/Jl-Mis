using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    
    public class EFProductRepo:IProductRepo
    {
        private EFDbContext1 context1 = new EFDbContext1();
        public IEnumerable<Product> Products
        {
            get { return context1.Products; }
        }
    }
}
