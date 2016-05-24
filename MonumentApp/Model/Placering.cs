using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonumentApp.Model
{
    class Placering 
    {
        public bool Jord { get; set; }
        public bool Bygning { get; set; }
        public bool Facade { get; set; }

        public Placering(bool jord, bool bygning, bool facade)
        {
            Jord = jord;
            Bygning = bygning;
            Facade = facade;
        }

        public Placering()
        {
            
        }

        public override string ToString()
        {
            return $"Jord: {Jord}, Bygning: {Bygning}, Facade: {Facade}";
        }
    }
}
