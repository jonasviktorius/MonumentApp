using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonumentApp.Persistency;

namespace MonumentApp.Model
{
    public class MonumentSingleton
    {
        private static MonumentSingleton instance = new MonumentSingleton();
        public static MonumentSingleton Instance
        {
            get { return instance; }
        }
        public ObservableCollection<MonumentOversigt> Monumenter { get; set; }
        private MonumentSingleton()
        {
            Monumenter = new ObservableCollection<MonumentOversigt>();
          
        }
        public void Add(string Navn, String Adresse, int PostNr, string Note, string Bevaringsværdi)
        {
            Monumenter.Add(new MonumentOversigt(Navn, Adresse, PostNr, Note, Bevaringsværdi));
        }
    }
}
