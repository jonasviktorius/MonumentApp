using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonumentApp.Model
{
    public class MonumentTyper
    {
        public bool Skulptur { get; set; }
        public bool Sokkel { get; set; }
        public bool Relief { get; set; }
        public bool Vandkunst { get; set; }

        public MonumentTyper(bool skulptur, bool sokkel, bool relief, bool vandkunst)
        {
            Skulptur = skulptur;
            Sokkel = sokkel;
            Relief = relief;
            Vandkunst = vandkunst;
        }
        public MonumentTyper()
        {

        }

        public override string ToString()
        {
            return $"Skulptur: {Skulptur}, Sokkel: {Sokkel}, Relief: {Relief}, Vandkunst: {Vandkunst}";
        }
    }
}
