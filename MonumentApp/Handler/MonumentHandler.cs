﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using MonumentApp.Model;
using MonumentApp.Persistency;
using MonumentApp.ViewModel;
using Newtonsoft.Json;

namespace MonumentApp.Handler
{
    public class MonumentHandler
    {
        public MonumentSingleton MonumentSingleton => MonumentSingleton.Instance;

        public MonumentHandler()
        {
        }

        public void OpretMonument()
        {
      
            FacadeLag facade = new FacadeLag();
            
           facade.SaveMonumentv2(StaticObjects.SelectedMonumenter, StaticObjects.SelectedPlaceringsTyper);
            //facade.SavePlacering(StaticObjects.SelectedPlaceringsTyper);
            //facade.SaveMonumentTyper(StaticObjects.SelectedMonumentTyper);
            //facade.SaveMaterialeTyper(StaticObjects.SelectedMaterialeTyper);


        }
    }
}
