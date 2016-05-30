using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService
{
    public class MaterialeTyperBinding
    {
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

    }
}
