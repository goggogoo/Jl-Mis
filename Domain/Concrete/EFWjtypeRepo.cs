using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    public class EFWjtypeRepo:IWjtypeRepo
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<WJ_TYPE> Wj_types
        {
            get { return context.WJ_TYPE; }
        }
    }
}
