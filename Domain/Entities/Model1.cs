namespace Domain.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<HT_FILES> HT_FILES { get; set; }
        public virtual DbSet<RS_USERS> RS_USERS { get; set; }
        public virtual DbSet<WJ_BASE> WJ_BASE { get; set; }
        public virtual DbSet<WJ_TYPE> WJ_TYPE { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HT_FILES>()
                .Property(e => e.HT_NO)
                .IsUnicode(false);

            modelBuilder.Entity<HT_FILES>()
                .Property(e => e.FAG)
                .IsUnicode(false);

            modelBuilder.Entity<RS_USERS>()
                .Property(e => e.LS_GH)
                .IsUnicode(false);

            modelBuilder.Entity<RS_USERS>()
                .Property(e => e.LS_XM)
                .IsUnicode(false);

            modelBuilder.Entity<RS_USERS>()
                .Property(e => e.LS_PWD)
                .IsUnicode(false);

            modelBuilder.Entity<RS_USERS>()
                .Property(e => e.LS_XL)
                .IsUnicode(false);

            modelBuilder.Entity<RS_USERS>()
                .Property(e => e.LS_ZC)
                .IsUnicode(false);

            modelBuilder.Entity<RS_USERS>()
                .Property(e => e.LS_BZ)
                .IsUnicode(false);

            modelBuilder.Entity<RS_USERS>()
                .Property(e => e.LS_ZW)
                .IsUnicode(false);

            modelBuilder.Entity<RS_USERS>()
                .Property(e => e.LS_SFZ)
                .IsUnicode(false);

            modelBuilder.Entity<RS_USERS>()
                .Property(e => e.LS_SJH)
                .IsUnicode(false);

            modelBuilder.Entity<RS_USERS>()
                .Property(e => e.LS_DHH)
                .IsUnicode(false);

            modelBuilder.Entity<RS_USERS>()
                .Property(e => e.LS_ZSMC1)
                .IsUnicode(false);

            modelBuilder.Entity<RS_USERS>()
                .Property(e => e.LS_ZSBH1)
                .IsUnicode(false);

            modelBuilder.Entity<RS_USERS>()
                .Property(e => e.LS_ZSMC2)
                .IsUnicode(false);

            modelBuilder.Entity<RS_USERS>()
                .Property(e => e.LS_ZSBH2)
                .IsUnicode(false);

            modelBuilder.Entity<RS_USERS>()
                .Property(e => e.LS_QX)
                .IsUnicode(false);

            modelBuilder.Entity<RS_USERS>()
                .Property(e => e.LS_MEMO)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_BASE>()
                .Property(e => e.LS_NO)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_BASE>()
                .Property(e => e.LS_FBBMMC)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_BASE>()
                .Property(e => e.LS_FBBMBH)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_BASE>()
                .Property(e => e.LS_FBRXM)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_BASE>()
                .Property(e => e.LS_FBRBH)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_BASE>()
                .Property(e => e.LS_FBZT)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_BASE>()
                .Property(e => e.LS_GJC)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_BASE>()
                .Property(e => e.LS_WJSM)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_BASE>()
                .Property(e => e.LS_WJLX)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_BASE>()
                .Property(e => e.LS_WJBZ)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_BASE>()
                .Property(e => e.LS_WJHZ)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_BASE>()
                .Property(e => e.LS_FJHZ)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_BASE>()
                .Property(e => e.LS_WJMC)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_BASE>()
                .Property(e => e.LS_FJMC)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_BASE>()
                .Property(e => e.LS_JSRLB)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_BASE>()
                .Property(e => e.LS_JSBMLB)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_BASE>()
                .Property(e => e.LS_JSRXS)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_BASE>()
                .Property(e => e.LS_JSBMXS)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_BASE>()
                .Property(e => e.LS_ELSE)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_TYPE>()
                .Property(e => e.LS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_TYPE>()
                .Property(e => e.LS_ELSE)
                .IsUnicode(false);
        }
    }
}
