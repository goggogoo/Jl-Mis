namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("JL_MIS.CL_CHLSHBTZH")]
    public partial class CL_CHLSHBTZH
    {
        [Key]
        [StringLength(20)]
        public string CHPHM { get; set; }

        [StringLength(40)]
        public string CHPXH { get; set; }

        public decimal? DUN { get; set; }

        public byte? ZUO { get; set; }

        [StringLength(10)]
        public string CHLLX { get; set; }

        [StringLength(10)]
        public string CHSHYS { get; set; }

        [StringLength(20)]
        public string ZHZCHJ { get; set; }

        public DateTime? CHCHRQ { get; set; }

        public DateTime? QYRQ { get; set; }

        [StringLength(20)]
        public string CHZHU { get; set; }

        [StringLength(20)]
        public string ZHZH { get; set; }

        [StringLength(20)]
        public string FDJHM { get; set; }

        [StringLength(20)]
        public string CHJHM { get; set; }

        [StringLength(10)]
        public string QD { get; set; }

        [StringLength(10)]
        public string RL { get; set; }

        [StringLength(800)]
        public string JSHCSH { get; set; }

        [StringLength(200)]
        public string BZH { get; set; }

        [StringLength(10)]
        public string DLR { get; set; }

        public byte[] PHOTO { get; set; }

        public short? PINDEX { get; set; }

        [StringLength(10)]
        public string PAILIANG { get; set; }

        public decimal? GZJG { get; set; }

        public decimal? LCBS { get; set; }
    }
}
