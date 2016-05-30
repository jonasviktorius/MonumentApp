
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebService.Models.Binding
{
    public class MonumentBinding
    {
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

        public bool Jord { get; set; }
        public bool Bygning { get; set; }
        public bool Facade { get; set; }


        public List<int> MonumentType_Ids { get; set; }

        public List<int> Placerings_Ids { get; set; }
    }
}
