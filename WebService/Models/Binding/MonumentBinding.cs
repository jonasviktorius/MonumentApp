
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

        // PlaceringsTyper
        public bool Jord { get; set; }
        public bool Bygning { get; set; }
        public bool Facade { get; set; }

        //Materiale 

        //Sten Materialet
        public bool Granit { get; set; }
        public bool Marmor { get; set; }
        public bool Sandsten { get; set; }
        public bool Kalksten { get; set; }

        // Metal Materiale
        public bool Bronze { get; set; }
        public bool Cortenstål { get; set; }
        public bool BemaletStål { get; set; }
        public bool Aluminium { get; set; }
        public bool Jern { get; set; }
        public bool AndetMetal { get; set; }

        //Andet Materiale
        public bool Trae { get; set; }
        public bool Tegl { get; set; }
        public bool Beton { get; set; }
        public bool AndetMateriale { get; set; }

        //Monument typer
        public bool Skulptur { get; set; }
        public bool Sokkel { get; set; }
        public bool Relief { get; set; }
        public bool Vandkunst { get; set; }

        public List<int> MonumentType_Ids { get; set; }

        public List<int> Placerings_Ids { get; set; }

        public List<int> Materiale_Ids { get; set; }
    }
}
