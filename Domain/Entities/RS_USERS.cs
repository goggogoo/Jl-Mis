namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("JL_MIS.RS_USERS")]
    public partial class RS_USERS
    {
        public int? ID { get; set; }

        [Key]
        [StringLength(10)]
        public string LS_GH { get; set; }

        [StringLength(10)]
        public string LS_XM { get; set; }

        [StringLength(10)]
        public string LS_PWD { get; set; }

        public bool? LI_XB { get; set; }

        public DateTime? LDT_CSRQ { get; set; }

        public DateTime? LDT_GZRQ { get; set; }

        [StringLength(10)]
        public string LS_XL { get; set; }

        [StringLength(12)]
        public string LS_ZC { get; set; }

        [StringLength(20)]
        public string LS_BZ { get; set; }

        [StringLength(20)]
        public string LS_ZW { get; set; }

        [StringLength(20)]
        public string LS_SFZ { get; set; }

        [StringLength(15)]
        public string LS_SJH { get; set; }

        [StringLength(15)]
        public string LS_DHH { get; set; }

        public bool? LI_ZT { get; set; }

        public byte? LI_JB { get; set; }

        public byte? LI_SIGN { get; set; }

        [StringLength(15)]
        public string LS_ZSMC1 { get; set; }

        [StringLength(15)]
        public string LS_ZSBH1 { get; set; }

        [StringLength(15)]
        public string LS_ZSMC2 { get; set; }

        [StringLength(15)]
        public string LS_ZSBH2 { get; set; }

        [StringLength(400)]
        public string LS_QX { get; set; }

        [StringLength(100)]
        public string LS_MEMO { get; set; }

        public byte[] LB_ZP { get; set; }
    }
}
