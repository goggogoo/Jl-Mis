using Domain.Abstract;
using Domain.Entities;
using System.Collections.Generic;
namespace Domain.Concrete
{
    public class EFUserRepo:IUserRepo
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<RS_USERS> Rs_users
        {
            get { return context.RS_USERS; }
        }
    }
}
