namespace WebService
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
            SkadeOversigt = new HashSet<SkadeOversigt>();
        }

        [Key]
        public int Global_Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Navn { get; set; }

        [Required]
        [StringLength(250)]
        public string Adresse { get; set; }

        public int? PostNr { get; set; }

        [StringLength(100)]
        public string Note { get; set; }

        [StringLength(1)]
        public string Bevaringsværdi { get; set; }

        public virtual PostNrTabel PostNrTabel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SkadeOversigt> SkadeOversigt { get; set; }
    }
}
