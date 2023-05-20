namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("JL_MIS.PB_MMENU")]
    public partial class PB_MMENU
    {
        [Key]
        public decimal NODE { get; set; }

        public decimal? PNODE { get; set; }

        [Required]
        [StringLength(30)]
        public string TEXT { get; set; }

        [StringLength(30)]
        public string TAG { get; set; }

        public decimal? ISFIN { get; set; }
    }
}
