namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("JL_MIS.CL_ASSTICKET")]
    public partial class CL_ASSTICKET
    {
        [Key]
        [StringLength(20)]
        public string SQBH { get; set; }

        public short? SIGN { get; set; }

        [StringLength(10)]
        public string SQRBH { get; set; }

        [StringLength(10)]
        public string SQRXM { get; set; }

        public short? SQRJB { get; set; }

        [StringLength(40)]
        public string BMMC { get; set; }

        [StringLength(40)]
        public string BMBH { get; set; }

        public short? CCRS { get; set; }

        public short? SNSW { get; set; }

        [StringLength(20)]
        public string HCDD { get; set; }

        [StringLength(20)]
        public string MDD { get; set; }

        [StringLength(200)]
        public string SQSY { get; set; }

        public DateTime? SQQSSJ { get; set; }

        public DateTime? SQJSSJ { get; set; }

        public DateTime? SQSJ { get; set; }

        [StringLength(200)]
        public string SQBZ { get; set; }

        [StringLength(10)]
        public string BMPFRBH { get; set; }

        [StringLength(10)]
        public string BMPFRXM { get; set; }

        public short? BMPFYJ { get; set; }

        public DateTime? BMPFSJ { get; set; }

        [StringLength(200)]
        public string BMPFBZ { get; set; }

        [StringLength(10)]
        public string BGSPFRBH { get; set; }

        [StringLength(10)]
        public string BGSPFRXM { get; set; }

        public short? BGSPFYJ { get; set; }

        public DateTime? BGSPFSJ { get; set; }

        [StringLength(200)]
        public string BGSPFBZ { get; set; }

        [StringLength(20)]
        public string CLDBH { get; set; }

        [StringLength(10)]
        public string CLDXM { get; set; }

        public short? CLDPFYJ { get; set; }

        public DateTime? CLDPFSJ { get; set; }

        [StringLength(100)]
        public string CLDPFBZ { get; set; }

        [StringLength(10)]
        public string BGSPCRBH { get; set; }

        [StringLength(10)]
        public string BGSPCRXM { get; set; }

        public DateTime? BGSPCSJ { get; set; }

        [StringLength(200)]
        public string BGSPCBZ { get; set; }

        [StringLength(20)]
        public string CPH1 { get; set; }

        [StringLength(20)]
        public string CPH2 { get; set; }

        [StringLength(20)]
        public string CPH3 { get; set; }

        [StringLength(10)]
        public string JSYBH1 { get; set; }

        [StringLength(10)]
        public string JSYXM1 { get; set; }

        [StringLength(10)]
        public string JSYBH2 { get; set; }

        [StringLength(10)]
        public string JSYXM2 { get; set; }

        [StringLength(10)]
        public string JSYBH3 { get; set; }

        [StringLength(10)]
        public string JSYXM3 { get; set; }

        [StringLength(10)]
        public string SJBH { get; set; }

        [StringLength(10)]
        public string SJXM { get; set; }

        public DateTime? SJSJ { get; set; }

        public DateTime? CCSJ { get; set; }

        public DateTime? SCSJ { get; set; }

        public decimal? LCBS10 { get; set; }

        public decimal? LCBS11 { get; set; }

        public decimal? HSGLS1 { get; set; }

        public decimal? JYL1 { get; set; }

        public decimal? JYF1 { get; set; }

        public decimal? GLGQF1 { get; set; }

        public decimal? QTF1 { get; set; }

        public decimal? LCBS20 { get; set; }

        public decimal? LCBS21 { get; set; }

        public decimal? HSGLS2 { get; set; }

        public decimal? JYL2 { get; set; }

        public decimal? JYF2 { get; set; }

        public decimal? GLGQF2 { get; set; }

        public decimal? QTF2 { get; set; }

        [StringLength(200)]
        public string SJBZ { get; set; }

        [StringLength(10)]
        public string HSRBH { get; set; }

        [StringLength(10)]
        public string HSRXM { get; set; }

        public DateTime? HSRSJ { get; set; }

        [StringLength(100)]
        public string HSRBZ { get; set; }

        public short? SFPC { get; set; }

        [StringLength(30)]
        public string SQRLXDH { get; set; }

        [StringLength(10)]
        public string BGSSPLDBH { get; set; }

        [StringLength(10)]
        public string BGSSPLDXM { get; set; }

        public short? FLAG { get; set; }
    }
}
