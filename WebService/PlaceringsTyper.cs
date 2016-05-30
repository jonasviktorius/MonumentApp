namespace WebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PlaceringsTyper")]
    public partial class PlaceringsTyper
    {
        [Key]
        public int Placerings_Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Placering { get; set; }
    }
}
