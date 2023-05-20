namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("JL_MIS.HT_FILES")]
    public partial class HT_FILES
    {
        [Key]
        [StringLength(30)]
        public string HT_NO { get; set; }

        public byte? SIGN { get; set; }

        [StringLength(10)]
        public string FAG { get; set; }

        public DateTime? RQ { get; set; }

        public byte[] NR { get; set; }
    }
}
