
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

        public bool Jord { get; set; }
        public bool Bygning { get; set; }
        public bool Facade { get; set; }


        public List<int> MonumentType_Ids { get; set; }

        public List<int> Placerings_Ids { get; set; }
    }
}
