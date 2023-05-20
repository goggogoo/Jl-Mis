using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    public class EFWjRepo:IWjbaseRepo
    {
        EFDbContext cxt = new EFDbContext();
        public IEnumerable<WJ_BASE> wjs
        {
            get {
                return cxt.WJ_BASE;
            }
        }
    }
}
