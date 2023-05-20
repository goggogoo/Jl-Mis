using System;
using System.Data.Entity;


namespace Domain.Entities
{

    public class EFDbContext2 : DbContext
    {
        public DbSet<RS_USERS> RS_USERS { get; set; }
        public DbSet<WJ_TYPE> WJ_TYPE { get; set; }
        public DbSet<HT_FILES> HT_FILES { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("JL_MIS");
        }
    }

}
