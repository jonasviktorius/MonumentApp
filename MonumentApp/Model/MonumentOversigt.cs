using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonumentApp.Model
{

    public class MonumentOversigt
    {
        public int Global_Id { get; set; }
        public string Navn { get; set; }
        public string Adresse { get; set; }
        public int? PostNr { get; set; }
        public string Note { get; set; }
        public string Bevaringsværdi { get; set; }
        public virtual PostNrTabel PostNrTabel { get; set; }
        public virtual ICollection<SkadeOversigt> SkadeOversigt { get; set; }
        public MonumentOversigt()
        {

        }
        public MonumentOversigt(string navn, string adresse, int? postNr, string note, string bevaringsværdi)
        {
            Navn = navn;
            Adresse = adresse;
            PostNr = postNr;
            Note = note;
            Bevaringsværdi = bevaringsværdi;
         }

        public static void CheckBevaringsværdi(string bevaringdværdi)
        {
            if (bevaringdværdi.Length == 0 || bevaringdværdi.Length > 1 || bevaringdværdi.Length < 1)
            {
                throw new Exception("bevaringdværdi er forkert");
            }
        }

        public override string ToString()
        {
            return $"Navn: {Navn}, Adresse: {Adresse}, PostNr: {PostNr}, Note: {Note}, Bevaringsværdig: {Bevaringsværdi}";
        }
    }
}
