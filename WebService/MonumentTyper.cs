namespace WebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MonumentTyper")]
    public partial class MonumentTyper
    {
        [Key]
        public int MonumentType_Id { get; set; }

        [StringLength(30)]
        public string MonumentType { get; set; }
    }
}
