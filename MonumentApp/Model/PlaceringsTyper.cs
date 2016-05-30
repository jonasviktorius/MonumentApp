using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonumentApp.Model
{
    public  class PlaceringsTyper 
    {
        public bool Jord { get; set; }
        public bool Bygning { get; set; }
        public bool Facade { get; set; }
        public PlaceringsTyper(bool jord, bool bygning, bool facade)
        {
            Jord = jord;
            Bygning = bygning;
            Facade = facade;
        }
        public PlaceringsTyper()
        {
        }
        public override string ToString()
        {
            return $"Jord: {Jord}, Bygning: {Bygning}, Facade: {Facade}";
        }
    }
}
