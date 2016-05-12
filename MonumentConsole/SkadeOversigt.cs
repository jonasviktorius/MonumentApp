namespace MonumentConsole
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SkadeOversigt")]
    public partial class SkadeOversigt
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Skade_Id { get; set; }

        public int Global_Id { get; set; }

        public int SkadeType_Id { get; set; }

        public bool ErSkadenUdbedret { get; set; }

        public virtual MonumentOversigt MonumentOversigt { get; set; }

        public virtual SkadeTyper SkadeTyper { get; set; }
    }
}
