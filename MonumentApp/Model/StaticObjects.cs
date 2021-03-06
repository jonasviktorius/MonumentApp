﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonumentApp.Model
{
public class StaticObjects
    {
        public static PostNrTabel SelectedPostNr { get; set; } = new PostNrTabel();
        public static MonumentOversigt SelectedMonumenter { get; set; } = new MonumentOversigt("", "", 0, "", "");
        public static PlaceringsTyper SelectedPlaceringsTyper { get; set; } = new PlaceringsTyper(false, false, false);
        public static PlaceringsOversigt SelectedPlaceringsOversigt { get; set; } = new PlaceringsOversigt();
        public static MonumentTyper SelectedMonumentTyper { get; set; } = new MonumentTyper(false, false, false, false);
        public static MonumentTypeOversigt SelectedMonumentTypeOversigt { get; set; } = new MonumentTypeOversigt();
        public static MaterialeTyper SelectedMaterialeTyper { get; set; } 
            = new MaterialeTyper(false, false, false, false, false, false, false, false, false, false, false, false, false, false);
        public static MaterialeOversigt SelectedMaterialeOversigt { get; set; } = new MaterialeOversigt();
    }
}
