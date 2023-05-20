namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("JL_MIS.WJ_TYPE")]
    public partial class WJ_TYPE
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int? LL_SORT { get; set; }

        [StringLength(30)]
        public string LS_ID { get; set; }

        public byte? LL_SIGN { get; set; }

        public byte? LL_ELSE { get; set; }

        [StringLength(20)]
        public string LS_ELSE { get; set; }
    }
}
