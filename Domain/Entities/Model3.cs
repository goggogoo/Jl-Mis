namespace Domain.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model3 : DbContext
    {
        public Model3()
            : base("name=Model3")
        {
        }

        public virtual DbSet<CC_MISSION> CC_MISSION { get; set; }
        public virtual DbSet<CL_ASSTICKET> CL_ASSTICKET { get; set; }
        public virtual DbSet<CL_CHLSHBTZH> CL_CHLSHBTZH { get; set; }
        public virtual DbSet<CL_SERVICETICKET> CL_SERVICETICKET { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CC_MISSION>()
                .Property(e => e.LS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CC_MISSION>()
                .Property(e => e.LS_BMMC)
                .IsUnicode(false);

            modelBuilder.Entity<CC_MISSION>()
                .Property(e => e.LS_BMBH)
                .IsUnicode(false);

            modelBuilder.Entity<CC_MISSION>()
                .Property(e => e.LS_CCSY)
                .IsUnicode(false);

            modelBuilder.Entity<CC_MISSION>()
                .Property(e => e.LS_CCDD)
                .IsUnicode(false);

            modelBuilder.Entity<CC_MISSION>()
                .Property(e => e.LS_CCRY)
                .IsUnicode(false);

            modelBuilder.Entity<CC_MISSION>()
                .Property(e => e.LS_WCQK)
                .IsUnicode(false);

            modelBuilder.Entity<CC_MISSION>()
                .Property(e => e.LS_BZ)
                .IsUnicode(false);

            modelBuilder.Entity<CC_MISSION>()
                .Property(e => e.LS_SQRXM)
                .IsUnicode(false);

            modelBuilder.Entity<CC_MISSION>()
                .Property(e => e.LS_SQRBH)
                .IsUnicode(false);

            modelBuilder.Entity<CC_MISSION>()
                .Property(e => e.LS_BMPFXM)
                .IsUnicode(false);

            modelBuilder.Entity<CC_MISSION>()
                .Property(e => e.LS_BMPFBH)
                .IsUnicode(false);

            modelBuilder.Entity<CC_MISSION>()
                .Property(e => e.LS_BMPFBZ)
                .IsUnicode(false);

            modelBuilder.Entity<CC_MISSION>()
                .Property(e => e.LS_GSPFXM)
                .IsUnicode(false);

            modelBuilder.Entity<CC_MISSION>()
                .Property(e => e.LS_GSPFBH)
                .IsUnicode(false);

            modelBuilder.Entity<CC_MISSION>()
                .Property(e => e.LS_GSPFBZ)
                .IsUnicode(false);

            modelBuilder.Entity<CC_MISSION>()
                .Property(e => e.LS_ELSE)
                .IsUnicode(false);

            modelBuilder.Entity<CL_ASSTICKET>()
                .Property(e => e.SQBH)
                .IsUnicode(false);

            modelBuilder.Entity<CL_ASSTICKET>()
                .Property(e => e.SQRBH)
                .IsUnicode(false);

            modelBuilder.Entity<CL_ASSTICKET>()
                .Property(e => e.SQRXM)
                .IsUnicode(false);

            modelBuilder.Entity<CL_ASSTICKET>()
                .Property(e => e.BMMC)
                .IsUnicode(false);

            modelBuilder.Entity<CL_ASSTICKET>()
                .Property(e => e.BMBH)
                .IsUnicode(false);

            modelBuilder.Entity<CL_ASSTICKET>()
                .Property(e => e.HCDD)
                .IsUnicode(false);

            modelBuilder.Entity<CL_ASSTICKET>()
                .Property(e => e.MDD)
                .IsUnicode(false);

            modelBuilder.Entity<CL_ASSTICKET>()
                .Property(e => e.SQSY)
                .IsUnicode(false);

            modelBuilder.Entity<CL_ASSTICKET>()
                .Property(e => e.SQBZ)
                .IsUnicode(false);

            modelBuilder.Entity<CL_ASSTICKET>()
                .Property(e => e.BMPFRBH)
                .IsUnicode(false);

            modelBuilder.Entity<CL_ASSTICKET>()
                .Property(e => e.BMPFRXM)
                .IsUnicode(false);

            modelBuilder.Entity<CL_ASSTICKET>()
                .Property(e => e.BMPFBZ)
                .IsUnicode(false);

            modelBuilder.Entity<CL_ASSTICKET>()
                .Property(e => e.BGSPFRBH)
                .IsUnicode(false);

            modelBuilder.Entity<CL_ASSTICKET>()
                .Property(e => e.BGSPFRXM)
                .IsUnicode(false);

            modelBuilder.Entity<CL_ASSTICKET>()
                .Property(e => e.BGSPFBZ)
                .IsUnicode(false);

            modelBuilder.Entity<CL_ASSTICKET>()
                .Property(e => e.CLDBH)
                .IsUnicode(false);

            modelBuilder.Entity<CL_ASSTICKET>()
                .Property(e => e.CLDXM)
                .IsUnicode(false);

            modelBuilder.Entity<CL_ASSTICKET>()
                .Property(e => e.CLDPFBZ)
                .IsUnicode(false);

            modelBuilder.Entity<CL_ASSTICKET>()
                .Property(e => e.BGSPCRBH)
                .IsUnicode(false);

            modelBuilder.Entity<CL_ASSTICKET>()
                .Property(e => e.BGSPCRXM)
                .IsUnicode(false);

            modelBuilder.Entity<CL_ASSTICKET>()
                .Property(e => e.BGSPCBZ)
                .IsUnicode(false);

            modelBuilder.Entity<CL_ASSTICKET>()
                .Property(e => e.CPH1)
                .IsUnicode(false);

            modelBuilder.Entity<CL_ASSTICKET>()
                .Property(e => e.CPH2)
                .IsUnicode(false);

            modelBuilder.Entity<CL_ASSTICKET>()
                .Property(e => e.CPH3)
                .IsUnicode(false);

            modelBuilder.Entity<CL_ASSTICKET>()
                .Property(e => e.JSYBH1)
                .IsUnicode(false);

            modelBuilder.Entity<CL_ASSTICKET>()
                .Property(e => e.JSYXM1)
                .IsUnicode(false);

            modelBuilder.Entity<CL_ASSTICKET>()
                .Property(e => e.JSYBH2)
                .IsUnicode(false);

            modelBuilder.Entity<CL_ASSTICKET>()
                .Property(e => e.JSYXM2)
                .IsUnicode(false);

            modelBuilder.Entity<CL_ASSTICKET>()
                .Property(e => e.JSYBH3)
                .IsUnicode(false);

            modelBuilder.Entity<CL_ASSTICKET>()
                .Property(e => e.JSYXM3)
                .IsUnicode(false);

            modelBuilder.Entity<CL_ASSTICKET>()
                .Property(e => e.SJBH)
                .IsUnicode(false);

            modelBuilder.Entity<CL_ASSTICKET>()
                .Property(e => e.SJXM)
                .IsUnicode(false);

            modelBuilder.Entity<CL_ASSTICKET>()
                .Property(e => e.LCBS10)
                .HasPrecision(12, 2);

            modelBuilder.Entity<CL_ASSTICKET>()
                .Property(e => e.LCBS11)
                .HasPrecision(12, 2);

            modelBuilder.Entity<CL_ASSTICKET>()
                .Property(e => e.HSGLS1)
                .HasPrecision(8, 2);

            modelBuilder.Entity<CL_ASSTICKET>()
                .Property(e => e.JYL1)
                .HasPrecision(8, 2);

            modelBuilder.Entity<CL_ASSTICKET>()
                .Property(e => e.JYF1)
                .HasPrecision(8, 2);

            modelBuilder.Entity<CL_ASSTICKET>()
                .Property(e => e.GLGQF1)
                .HasPrecision(8, 2);

            modelBuilder.Entity<CL_ASSTICKET>()
                .Property(e => e.QTF1)
                .HasPrecision(8, 2);

            modelBuilder.Entity<CL_ASSTICKET>()
                .Property(e => e.LCBS20)
                .HasPrecision(12, 2);

            modelBuilder.Entity<CL_ASSTICKET>()
                .Property(e => e.LCBS21)
                .HasPrecision(12, 2);

            modelBuilder.Entity<CL_ASSTICKET>()
                .Property(e => e.HSGLS2)
                .HasPrecision(8, 2);

            modelBuilder.Entity<CL_ASSTICKET>()
                .Property(e => e.JYL2)
                .HasPrecision(8, 2);

            modelBuilder.Entity<CL_ASSTICKET>()
                .Property(e => e.JYF2)
                .HasPrecision(8, 2);

            modelBuilder.Entity<CL_ASSTICKET>()
                .Property(e => e.GLGQF2)
                .HasPrecision(8, 2);

            modelBuilder.Entity<CL_ASSTICKET>()
                .Property(e => e.QTF2)
                .HasPrecision(8, 2);

            modelBuilder.Entity<CL_ASSTICKET>()
                .Property(e => e.SJBZ)
                .IsUnicode(false);

            modelBuilder.Entity<CL_ASSTICKET>()
                .Property(e => e.HSRBH)
                .IsUnicode(false);

            modelBuilder.Entity<CL_ASSTICKET>()
                .Property(e => e.HSRXM)
                .IsUnicode(false);

            modelBuilder.Entity<CL_ASSTICKET>()
                .Property(e => e.HSRBZ)
                .IsUnicode(false);

            modelBuilder.Entity<CL_ASSTICKET>()
                .Property(e => e.SQRLXDH)
                .IsUnicode(false);

            modelBuilder.Entity<CL_ASSTICKET>()
                .Property(e => e.BGSSPLDBH)
                .IsUnicode(false);

            modelBuilder.Entity<CL_ASSTICKET>()
                .Property(e => e.BGSSPLDXM)
                .IsUnicode(false);

            modelBuilder.Entity<CL_CHLSHBTZH>()
                .Property(e => e.CHPHM)
                .IsUnicode(false);

            modelBuilder.Entity<CL_CHLSHBTZH>()
                .Property(e => e.CHPXH)
                .IsUnicode(false);

            modelBuilder.Entity<CL_CHLSHBTZH>()
                .Property(e => e.DUN)
                .HasPrecision(3, 1);

            modelBuilder.Entity<CL_CHLSHBTZH>()
                .Property(e => e.CHLLX)
                .IsUnicode(false);

            modelBuilder.Entity<CL_CHLSHBTZH>()
                .Property(e => e.CHSHYS)
                .IsUnicode(false);

            modelBuilder.Entity<CL_CHLSHBTZH>()
                .Property(e => e.ZHZCHJ)
                .IsUnicode(false);

            modelBuilder.Entity<CL_CHLSHBTZH>()
                .Property(e => e.CHZHU)
                .IsUnicode(false);

            modelBuilder.Entity<CL_CHLSHBTZH>()
                .Property(e => e.ZHZH)
                .IsUnicode(false);

            modelBuilder.Entity<CL_CHLSHBTZH>()
                .Property(e => e.FDJHM)
                .IsUnicode(false);

            modelBuilder.Entity<CL_CHLSHBTZH>()
                .Property(e => e.CHJHM)
                .IsUnicode(false);

            modelBuilder.Entity<CL_CHLSHBTZH>()
                .Property(e => e.QD)
                .IsUnicode(false);

            modelBuilder.Entity<CL_CHLSHBTZH>()
                .Property(e => e.RL)
                .IsUnicode(false);

            modelBuilder.Entity<CL_CHLSHBTZH>()
                .Property(e => e.JSHCSH)
                .IsUnicode(false);

            modelBuilder.Entity<CL_CHLSHBTZH>()
                .Property(e => e.BZH)
                .IsUnicode(false);

            modelBuilder.Entity<CL_CHLSHBTZH>()
                .Property(e => e.DLR)
                .IsUnicode(false);

            modelBuilder.Entity<CL_CHLSHBTZH>()
                .Property(e => e.PAILIANG)
                .IsUnicode(false);

            modelBuilder.Entity<CL_CHLSHBTZH>()
                .Property(e => e.GZJG)
                .HasPrecision(8, 4);

            modelBuilder.Entity<CL_CHLSHBTZH>()
                .Property(e => e.LCBS)
                .HasPrecision(12, 2);

            modelBuilder.Entity<CL_SERVICETICKET>()
                .Property(e => e.WXBH)
                .IsUnicode(false);

            modelBuilder.Entity<CL_SERVICETICKET>()
                .Property(e => e.SQRBH)
                .IsUnicode(false);

            modelBuilder.Entity<CL_SERVICETICKET>()
                .Property(e => e.SQRXM)
                .IsUnicode(false);

            modelBuilder.Entity<CL_SERVICETICKET>()
                .Property(e => e.CPH)
                .IsUnicode(false);

            modelBuilder.Entity<CL_SERVICETICKET>()
                .Property(e => e.YSFY)
                .HasPrecision(8, 2);

            modelBuilder.Entity<CL_SERVICETICKET>()
                .Property(e => e.SJFY)
                .HasPrecision(8, 2);

            modelBuilder.Entity<CL_SERVICETICKET>()
                .Property(e => e.BZSX)
                .IsUnicode(false);

            modelBuilder.Entity<CL_SERVICETICKET>()
                .Property(e => e.BMPFRBH)
                .IsUnicode(false);

            modelBuilder.Entity<CL_SERVICETICKET>()
                .Property(e => e.BMPFRXM)
                .IsUnicode(false);

            modelBuilder.Entity<CL_SERVICETICKET>()
                .Property(e => e.BMPFBZ)
                .IsUnicode(false);

            modelBuilder.Entity<CL_SERVICETICKET>()
                .Property(e => e.CLDBH)
                .IsUnicode(false);

            modelBuilder.Entity<CL_SERVICETICKET>()
                .Property(e => e.CLDXM)
                .IsUnicode(false);

            modelBuilder.Entity<CL_SERVICETICKET>()
                .Property(e => e.CLDPFBZ)
                .IsUnicode(false);

            modelBuilder.Entity<CL_SERVICETICKET>()
                .Property(e => e.LRRBH)
                .IsUnicode(false);

            modelBuilder.Entity<CL_SERVICETICKET>()
                .Property(e => e.LRRXM)
                .IsUnicode(false);

            modelBuilder.Entity<CL_SERVICETICKET>()
                .Property(e => e.LRRBZ)
                .IsUnicode(false);

            modelBuilder.Entity<CL_SERVICETICKET>()
                .Property(e => e.HSRBH)
                .IsUnicode(false);

            modelBuilder.Entity<CL_SERVICETICKET>()
                .Property(e => e.HSRXM)
                .IsUnicode(false);

            modelBuilder.Entity<CL_SERVICETICKET>()
                .Property(e => e.HSRBZ)
                .IsUnicode(false);

            modelBuilder.Entity<CL_SERVICETICKET>()
                .Property(e => e.XMNR)
                .IsUnicode(false);
        }
    }
}
