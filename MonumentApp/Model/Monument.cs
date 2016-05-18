using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonumentApp.Model
{
    class Monument
    {
        public string GlobalId { get; set; }
        public string Navn { get; set; }
        public string Adresse { get; set; }
        public int PostNr { get; set; }
        public string Note { get; set; }
        public string Bevaringsværdig { get; set; }

        public Monument()
        {
            
        }
        public Monument(string globalId, string navn, string adresse, string bevaringsværdig)
        {
            GlobalId = globalId;
            Navn = navn;
            Adresse = adresse;
            Bevaringsværdig = bevaringsværdig;
        }
        

        public override string ToString()
        {
            return $"GlobalId: {GlobalId}, Navn: {Navn}, Adresse: {Adresse}, Bevaringsværdig: {Bevaringsværdig}";
        }
    }
}
