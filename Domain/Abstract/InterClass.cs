using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract
{
    public class InterClass
    {
        public interface IUserRepo
        {
            IEnumerable<RS_USERS> Rs_users { get; }
        }
    }
}
