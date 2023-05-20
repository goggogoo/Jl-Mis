using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Abstract.InterClass;

namespace Domain.Concrete
{
    public class Concreteclass
    {
        public class UserRepo : IUserRepo
        {
            public IEnumerable<RS_USERS> Rs_users {
            get
                {
                    DataContext ctx = new DataContext("Data Source=orcl;Persist Security Info=True;User ID=jl_mis;Password=jl_mis");
                    IEnumerable<RS_USERS> rus = ctx.GetTable<RS_USERS>();

                    return rus;
                }
            }
        }
    }
}
