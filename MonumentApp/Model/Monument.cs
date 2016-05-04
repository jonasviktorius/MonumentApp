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


        public Monument(string globalId, string navn, string adresse, int postNr)
        {
            GlobalId = globalId;
            Navn = navn;
            Adresse = adresse;
            PostNr = postNr;
        }

        public override string ToString()
        {
            return $"GlobalId: {GlobalId}, Navn: {Navn}, Adresse: {Adresse}, PostNr: {PostNr}";
        }
    }
}
