namespace MonumentConsole
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MaterialeTyper")]
    public partial class MaterialeTyper
    {
        [Key]
        public int Materiale_Id { get; set; }

        [Required]
        [StringLength(30)]
        public string MaterialeType { get; set; }
    }
}
