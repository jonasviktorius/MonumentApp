using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonumentApp.Model
{
public class StaticObjects
    {
        public static MonumentOversigt SelectedMonumenter { get; set; } = new MonumentOversigt("","","");
        public static PlaceringsTyper SelectedPlaceringsTyper { get; set; } = new PlaceringsTyper(false,false,false);
    }
}
