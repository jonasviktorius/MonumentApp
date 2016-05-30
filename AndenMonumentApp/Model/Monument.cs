using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndenMonumentApp.Model
{
    public class Monument
    {
        public string Navn { get; set; }
        public string Adresse { get; set; }
        public int  PostNr { get; set; }


        public Monument()
        {
            
        }

        public Monument(string navn, string adresse, int postNr)
        {
            Navn = navn;
            Adresse = adresse;
            PostNr = postNr;
        }

        public override string ToString()
        {
            return $"Navn: {Navn}, Addresse: {Adresse}, PostNr: {PostNr}";
        }
    }
}
