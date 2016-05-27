using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonumentApp.Model
{
    public class MaterialeTyper
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

        public MaterialeTyper(bool granit, bool marmor, bool sandsten, bool kalksten, bool bronze, bool cortenstål, bool bemaletStål, bool aluminium, bool jern, bool andetMetal, bool trae, bool tegl, bool beton, bool andetMateriale)
        {
            Granit = granit;
            Marmor = marmor;
            Sandsten = sandsten;
            Kalksten = kalksten;
            Bronze = bronze;
            Cortenstål = cortenstål;
            BemaletStål = bemaletStål;
            Aluminium = aluminium;
            Jern = jern;
            AndetMetal = andetMetal;
            Trae = trae;
            Tegl = tegl;
            Beton = beton;
            AndetMateriale = andetMateriale;
        }

        public MaterialeTyper()
        {

        }

        public override string ToString()
        {
            return $"Granit: {Granit}, Marmor: {Marmor}, Sandsten: {Sandsten}, Kalksten: {Kalksten}, Bronze: {Bronze}, Cortenstål: {Cortenstål}, BemaletStål: {BemaletStål}, Aluminium: {Aluminium}, Jern: {Jern}, AndetMetal: {AndetMetal}, Trae: {Trae}, Tegl: {Tegl}, Beton: {Beton}, AndetMateriale: {AndetMateriale}";
        }
    }
}
