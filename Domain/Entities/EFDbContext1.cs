using System;
using System.Data.Entity;


namespace Domain.Entities
{

    class EFDbContext1 : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public System.Data.Entity.DbSet<Domain.Entities.WJ_BASE> WJ_BASE { get; set; }
    }

}
