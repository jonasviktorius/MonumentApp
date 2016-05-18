using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonumentApp.Model
{
    class Skade
    {
        public string Skade_Id { get; set; }
        public string SkadeType_Id { get; set; }
        public bool ErSkadenUdbedret { get; set; }

        public Skade(string skadeId, string globalId, string skadeTypeId, bool erSkadenUdbedret)
        {
            Skade_Id = skadeId;
            SkadeType_Id = skadeTypeId;
            ErSkadenUdbedret = erSkadenUdbedret;
        }

        public override string ToString()
        {
            return $"Skade_Id: {Skade_Id}, SkadeType_Id: {SkadeType_Id}, ErSkadenUdbedret: {ErSkadenUdbedret}";
        }
    }
}
