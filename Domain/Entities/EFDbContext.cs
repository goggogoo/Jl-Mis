using System;
using System.Data.Entity;


namespace Domain.Entities
{

    public class EFDbContext:DbContext
    {
        //加密连接，默认为随便填一个标准连接字符串
        //public EFDbContext() : base("DATA SOURCE=.;PERSIST SECURITY INFO=True;USER ID=.;Password=.")
        //{
        //    base.Database.Connection.ConnectionString= System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(System.Configuration.ConfigurationManager.ConnectionStrings["EFpp"].ConnectionString));
        //}
    public EFDbContext() : base(constr())
        {
        }
        private static string constr()
        {
            //return System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(System.Configuration.ConfigurationManager.ConnectionStrings["EFencode"].ConnectionString));
            //return "metadata=res://*/Entities.Model1.csdl|res://*/Entities.Model1.ssdl|res://*/Entities.Model1.msl;provider=Oracle.ManagedDataAccess.Client;provider connection string=\"DATA SOURCE=192.168.182.236:1521/orcl;PASSWORD=jl_mis;PERSIST SECURITY INFO=True;USER ID=JL_MIS\"";
            //return "metadata=res://*/Entities.Model1.csdl|res://*/Entities.Model1.ssdl|res://*/Entities.Model1.msl;provider=Oracle.ManagedDataAccess.Client;provider connection string=\"DATA SOURCE=192.168.182.236:1521/orcl;PASSWORD=jl_mis;PERSIST SECURITY INFO=True;USER ID=JL_MIS\"";
            return "DATA SOURCE=192.168.182.236:1521/orcl;PASSWORD=jl_mis;PERSIST SECURITY INFO=True;USER ID=JL_MIS";
                
        }
        public DbSet<RS_USERS> RS_USERS { get; set; }
        public DbSet<WJ_TYPE> WJ_TYPE{ get; set; }
        public DbSet<HT_FILES> HT_FILES { get; set; }
        public DbSet<WJ_BASE> WJ_BASE { get; set; }
        public DbSet<WJ_HANDLE> WJ_HANDLE { get; set; }
        public DbSet<PB_MMENU> PB_MMENU { get; set; }
        public DbSet<RS_BMTV> RS_BMTV { get; set; }
        public DbSet<CC_MISSION> CC_MISSION { get; set; }
        public DbSet<CL_ASSTICKET> CL_ASSTICKET { get; set; }
        public DbSet<CL_CHLSHBTZH> CL_CHLSHBTZH { get; set; }
        public DbSet<CL_SERVICETICKET> CL_SERVICETICKET { get; set; }
        public DbSet<TICK_OPR_DET> TICK_OPR_DET { get; set; }
        
        //默认用户dbo，oracle改为用户名
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("JL_MIS");
        }
    }

}
