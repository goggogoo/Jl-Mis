namespace Domain.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model2 : DbContext
    {
        public Model2()
            : base("name=Model2")
        {
        }

        public virtual DbSet<RS_BMTV> RS_BMTV { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RS_BMTV>()
                .Property(e => e.DISPLAYTEXT)
                .IsUnicode(false);

            modelBuilder.Entity<RS_BMTV>()
                .Property(e => e.TAGDATA)
                .IsUnicode(false);

            modelBuilder.Entity<RS_BMTV>()
                .Property(e => e.PICTUREINDEX)
                .IsUnicode(false);

            modelBuilder.Entity<RS_BMTV>()
                .Property(e => e.SELECTEDPICTUREINDEX)
                .IsUnicode(false);

            modelBuilder.Entity<RS_BMTV>()
                .Property(e => e.STATEPICTUREINDEX)
                .IsUnicode(false);

            modelBuilder.Entity<RS_BMTV>()
                .Property(e => e.LS_DIS)
                .IsUnicode(false);

            modelBuilder.Entity<RS_BMTV>()
                .Property(e => e.LS_FZR)
                .IsUnicode(false);
        }
    }
}
