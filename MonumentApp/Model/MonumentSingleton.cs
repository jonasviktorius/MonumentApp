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
            //MonumentOversigt m1 = new MonumentOversigt("430", "Frederik den store", "Poppelvej 12", "B");
            //MonumentOversigt m2 = new MonumentOversigt("450", "Avekat", "Voldvej 12", "C");
            //MonumentOversigt m3 = new MonumentOversigt("451", "Skaleaekw", "Hejvej 12", "A");
            //Monumenter.Add(m1);
            //Monumenter.Add(m2);
            //Monumenter.Add(m3);

            //Monumenter = new ObservableCollection<MonumentOversigt>(new FacadeLag().GetMonumenter());
        }

        public void Add(string Navn, String Adresse, string Bevaringsværdig)
        {
            Monumenter.Add(new MonumentOversigt(Navn, Adresse, Bevaringsværdig));
        }
    }
}
