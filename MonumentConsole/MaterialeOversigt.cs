namespace MonumentConsole
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MaterialeOversigt")]
    public partial class MaterialeOversigt
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string Materiale_Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Global_Id { get; set; }
    }
}
