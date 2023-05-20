namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("JL_MIS.CC_MISSION")]
    public partial class CC_MISSION
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(20)]
        public string LS_ID { get; set; }

        public byte? LL_SIGN { get; set; }

        [StringLength(30)]
        public string LS_BMMC { get; set; }

        [StringLength(30)]
        public string LS_BMBH { get; set; }

        [StringLength(100)]
        public string LS_CCSY { get; set; }

        [StringLength(100)]
        public string LS_CCDD { get; set; }

        [StringLength(100)]
        public string LS_CCRY { get; set; }

        public DateTime? LDT_JHRQ1 { get; set; }

        public DateTime? LDT_JHRQ2 { get; set; }

        public DateTime? LDT_SJRQ1 { get; set; }

        public DateTime? LDT_SJRQ2 { get; set; }

        [StringLength(300)]
        public string LS_WCQK { get; set; }

        [StringLength(100)]
        public string LS_BZ { get; set; }

        [StringLength(20)]
        public string LS_SQRXM { get; set; }

        [StringLength(20)]
        public string LS_SQRBH { get; set; }

        public DateTime? LDT_SQRQ { get; set; }

        [StringLength(20)]
        public string LS_BMPFXM { get; set; }

        [StringLength(20)]
        public string LS_BMPFBH { get; set; }

        public DateTime? LDT_BMPFRQ { get; set; }

        public byte? LL_BMPFYJ { get; set; }

        [StringLength(100)]
        public string LS_BMPFBZ { get; set; }

        [StringLength(20)]
        public string LS_GSPFXM { get; set; }

        [StringLength(20)]
        public string LS_GSPFBH { get; set; }

        public DateTime? LDT_GSPFRQ { get; set; }

        public byte? LL_GSPFYJ { get; set; }

        [StringLength(100)]
        public string LS_GSPFBZ { get; set; }

        public byte? LL_ELSE { get; set; }

        [StringLength(20)]
        public string LS_ELSE { get; set; }
    }
}
