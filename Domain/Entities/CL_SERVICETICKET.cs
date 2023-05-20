namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("JL_MIS.CL_SERVICETICKET")]
    public partial class CL_SERVICETICKET
    {
        [Key]
        [StringLength(20)]
        public string WXBH { get; set; }

        public short? SIGN { get; set; }

        [StringLength(10)]
        public string SQRBH { get; set; }

        [StringLength(10)]
        public string SQRXM { get; set; }

        public DateTime? SQRSJ { get; set; }

        [StringLength(20)]
        public string CPH { get; set; }

        public decimal? YSFY { get; set; }

        public decimal? SJFY { get; set; }

        [StringLength(200)]
        public string BZSX { get; set; }

        [StringLength(10)]
        public string BMPFRBH { get; set; }

        [StringLength(10)]
        public string BMPFRXM { get; set; }

        public short? BMPFYJ { get; set; }

        public DateTime? BMPFSJ { get; set; }

        [StringLength(200)]
        public string BMPFBZ { get; set; }

        [StringLength(20)]
        public string CLDBH { get; set; }

        [StringLength(10)]
        public string CLDXM { get; set; }

        public short? CLDPFYJ { get; set; }

        public DateTime? CLDPFSJ { get; set; }

        [StringLength(100)]
        public string CLDPFBZ { get; set; }

        [StringLength(10)]
        public string LRRBH { get; set; }

        [StringLength(10)]
        public string LRRXM { get; set; }

        public DateTime? LRRSJ { get; set; }

        public DateTime? WCSJ { get; set; }

        [StringLength(100)]
        public string LRRBZ { get; set; }

        [StringLength(10)]
        public string HSRBH { get; set; }

        [StringLength(10)]
        public string HSRXM { get; set; }

        public DateTime? HSRSJ { get; set; }

        [StringLength(100)]
        public string HSRBZ { get; set; }

        public short? FLAG { get; set; }

        public string XMNR { get; set; }
    }
}
