namespace MonumentConsole
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PlaceringsTyper")]
    public partial class PlaceringsTyper
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PlaceringsTyper()
        {
            MonumentOversigts = new HashSet<MonumentOversigt>();
        }

        [Key]
        [StringLength(30)]
        public string Placerings_Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Placering { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MonumentOversigt> MonumentOversigts { get; set; }
    }
}
