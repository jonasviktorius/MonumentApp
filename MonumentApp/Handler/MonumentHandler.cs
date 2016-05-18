using System;
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
    class MonumentHandler
    {
   

        public MonumentViewModel MonumentViewModel { get; set; }

        public MonumentHandler(MonumentViewModel monumentViewModel)
        {
            MonumentViewModel = monumentViewModel;
        }

        public void OpretMonument()
        {
            Monument monument = new Monument();
           
            monument.Navn = MonumentViewModel.NytMonument.Navn;
            monument.Adresse = MonumentViewModel.NytMonument.Adresse;
            monument.Bevaringsværdi = MonumentViewModel.NytMonument.Bevaringsværdi;
            new FacadeLag().SaveMonument(monument);

            var monumenter = new FacadeLag().GetMonumenter();

            MonumentViewModel.MonumentSingleton.Monumenter.Clear();
            foreach (var monument1 in monumenter)
            {
                MonumentViewModel.MonumentSingleton.Monumenter.Add(monument1);
            }

            MonumentViewModel.NytMonument.Navn = "";
            MonumentViewModel.NytMonument.Adresse = "";
            MonumentViewModel.NytMonument.Bevaringsværdi = "";

        }

        
    }
}
