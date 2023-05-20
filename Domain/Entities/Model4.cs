namespace Domain.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model4 : DbContext
    {
        public Model4()
            : base("name=Model4")
        {
        }

        public virtual DbSet<TICK_OPR_DET> TICK_OPR_DET { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TICK_OPR_DET>()
                .Property(e => e.ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TICK_OPR_DET>()
                .Property(e => e.PID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TICK_OPR_DET>()
                .Property(e => e.LLORD)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TICK_OPR_DET>()
                .Property(e => e.LLMN)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TICK_OPR_DET>()
                .Property(e => e.LLSJ)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TICK_OPR_DET>()
                .Property(e => e.LSXM)
                .IsUnicode(false);
        }
    }
}
