using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonumentApp.Model
{
    class Skade
    {
        public string SkadeId { get; set; }
        public string Type { get; set; }
        public string PlaceringsId { get; set; } //FK
        public string GlobalId { get; set; } //PK

    }
}
