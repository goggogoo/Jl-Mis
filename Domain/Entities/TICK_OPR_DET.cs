namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("JL_MIS.TICK_OPR_DET")]
    public partial class TICK_OPR_DET
    {
        public decimal ID { get; set; }

        public decimal? PID { get; set; }

        public decimal? LLORD { get; set; }

        public decimal? LLMN { get; set; }

        public decimal? LLSJ { get; set; }

        [StringLength(100)]
        public string LSXM { get; set; }

        public DateTime? LDTSJ { get; set; }
    }
}
