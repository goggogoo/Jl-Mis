using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    public class EFHtRepo
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<HT_FILES> Ht_files
        {
            get { return context.HT_FILES; }
        }
    }
}
