using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonumentApp.Model
{
    class Monument
    {
        public string Navn { get; set; }
        public string Adresse { get; set; }
        public int PostNr { get; set; }
        public string Note { get; set; }
        public string Bevaringsværdi { get; set; }

        public Monument()
        {
            
        }
        public Monument(string navn, string adresse, string bevaringsværdi)
        {
            Navn = navn;
            Adresse = adresse;
            Bevaringsværdi = bevaringsværdi;
        }
        

        public override string ToString()
        {
            return $"Navn: {Navn}, Adresse: {Adresse}, Bevaringsværdig: {Bevaringsværdi}";
        }
    }
}
