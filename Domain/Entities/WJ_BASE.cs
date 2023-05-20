namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("JL_MIS.WJ_BASE")]
    public partial class WJ_BASE
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(30)]
        public string LS_NO { get; set; }

        public int? LL_SIGN { get; set; }

        [StringLength(30)]
        public string LS_FBBMMC { get; set; }

        [StringLength(30)]
        public string LS_FBBMBH { get; set; }

        [StringLength(20)]
        public string LS_FBRXM { get; set; }

        [StringLength(20)]
        public string LS_FBRBH { get; set; }

        public DateTime? LDT_FBRRQ { get; set; }

        [StringLength(100)]
        public string LS_FBZT { get; set; }

        [StringLength(100)]
        public string LS_GJC { get; set; }

        [StringLength(100)]
        public string LS_WJSM { get; set; }

        [StringLength(30)]
        public string LS_WJLX { get; set; }

        [StringLength(100)]
        public string LS_WJBZ { get; set; }

        public byte? LL_WJCZ { get; set; }

        public byte? LL_FJCZ { get; set; }

        [StringLength(10)]
        public string LS_WJHZ { get; set; }

        [StringLength(10)]
        public string LS_FJHZ { get; set; }

        [StringLength(100)]
        public string LS_WJMC { get; set; }

        [StringLength(100)]
        public string LS_FJMC { get; set; }

        public string LS_JSRLB { get; set; }

        public string LS_JSBMLB { get; set; }

        public string LS_JSRXS { get; set; }

        public string LS_JSBMXS { get; set; }

        public short? LL_YBGS { get; set; }

        public byte? LL_YYGS { get; set; }

        public byte? LL_ELSE { get; set; }

        [StringLength(20)]
        public string LS_ELSE { get; set; }
    }
}
