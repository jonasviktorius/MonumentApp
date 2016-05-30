
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MonumentApp.Model.Binding
{
    public class MonumentBinding
    {
        public string Navn { get; set; }

        public string Adresse { get; set; }

        public int? PostNr { get; set; }

        public string Note { get; set; }

        public string Bevaringsværdi { get; set; }

        public virtual PostNrTabel PostNrTabel { get; set; }

        public virtual ICollection<SkadeOversigt> SkadeOversigt { get; set; }

        //Placering
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
