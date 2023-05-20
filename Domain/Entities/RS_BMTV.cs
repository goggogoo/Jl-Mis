namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("JL_MIS.RS_BMTV")]
    public partial class RS_BMTV
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short NODE { get; set; }

        public short? PARENTNODE { get; set; }

        [StringLength(30)]
        public string DISPLAYTEXT { get; set; }

        [StringLength(50)]
        public string TAGDATA { get; set; }

        public short? SORTORDER { get; set; }

        [StringLength(20)]
        public string PICTUREINDEX { get; set; }

        [StringLength(20)]
        public string SELECTEDPICTUREINDEX { get; set; }

        [StringLength(20)]
        public string STATEPICTUREINDEX { get; set; }

        public short? EXPANDED { get; set; }

        public byte? LI_JB { get; set; }

        public byte? LI_LX { get; set; }

        [StringLength(50)]
        public string LS_DIS { get; set; }

        [StringLength(10)]
        public string LS_FZR { get; set; }
    }
}
