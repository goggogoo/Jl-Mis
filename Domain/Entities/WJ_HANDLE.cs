namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("JL_MIS.WJ_HANDLE")]
    public partial class WJ_HANDLE
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int? LL_WJID { get; set; }

        public byte? LL_SIGN { get; set; }

        [StringLength(30)]
        public string LS_BLBMMC { get; set; }

        [StringLength(30)]
        public string LS_BLBMBH { get; set; }

        [StringLength(20)]
        public string LS_BLRXM { get; set; }

        [StringLength(20)]
        public string LS_BLRBH { get; set; }

        public DateTime? LDT_BLRRQ { get; set; }

        [StringLength(200)]
        public string LS_BLYJ { get; set; }

        public byte? LL_BLYJ { get; set; }

        public byte? LL_ELSE { get; set; }

        [StringLength(20)]
        public string LS_ELSE { get; set; }
    }
}
