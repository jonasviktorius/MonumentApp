using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using AndenMonumentApp.Model;
using AndenMonumentApp.ViewModel;

namespace AndenMonumentApp
{
    public class Handler
    {
       public string Navn { get; set; }
       public string Adresse { get; set; }
        public int PostNr { get; set; }
        public MonumentViewModel MonumentViewModel { get; set; }

        public Handler(MonumentViewModel monumentViewModel)
        {
            MonumentViewModel = monumentViewModel;
        }

        public void OpretMonument()
        {
            var monu = FacadeLag<Monument>.LoadDB("api/MonumentOversigts").Result;

            FacadeLag<Monument>.GemDB("api/MonumentOversigts", new Monument(Navn, Adresse, PostNr));
        }
    }
}
