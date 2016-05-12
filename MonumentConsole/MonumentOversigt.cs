namespace MonumentConsole
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MonumentOversigt")]
    public partial class MonumentOversigt
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MonumentOversigt()
        {
            SkadeOversigts = new HashSet<SkadeOversigt>();
        }

        [Key]
        public int Global_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Navn { get; set; }

        [Required]
        [StringLength(50)]
        public string Adresse { get; set; }

        public int? PostNr { get; set; }

        [Required]
        [StringLength(30)]
        public string Placerings_Id { get; set; }

        [StringLength(1)]
        public string Bevaringsværdig_Id { get; set; }

        [StringLength(255)]
        public string Note { get; set; }

        public virtual PlaceringsTyper PlaceringsTyper { get; set; }

        public virtual PostNrTabel PostNrTabel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SkadeOversigt> SkadeOversigts { get; set; }
    }
}
