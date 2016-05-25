using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonumentApp.Persistency;

namespace MonumentApp.Model
{
    class MonumentOversigtSingleton
    {
        private static MonumentOversigtSingleton instance = new MonumentOversigtSingleton();

        public static MonumentOversigtSingleton Instance
        {
            get { return instance; }
        }

        public ObservableCollection<MonumentOversigt> MonumentOversigts { get; set; }

        private MonumentOversigtSingleton()
        {
            //MonumenterOversigt = new ObservableCollection<MonumentOversigt>();
            //MonumentOversigt m1 = new MonumentOversigt("430", "Frederik den store", "Poppelvej 12", "B");
            //MonumentOversigt m2 = new MonumentOversigt("450", "Avekat", "Voldvej 12", "C");
            //MonumentOversigt m3 = new MonumentOversigt("451", "Skaleaekw", "Hejvej 12", "A");
            //Monumenter.Add(m1);
            //Monumenter.Add(m2);
            //Monumenter.Add(m3);

            MonumentOversigts = new ObservableCollection<MonumentOversigt>(new FacadeLag().GetMonumentOversigts());
        }

        public void Add(string GlobalId, string Navn, String Adresse, string Bevaringsværdig)
        {
            MonumentOversigts.Add(new MonumentOversigt(GlobalId, Navn, Adresse, Bevaringsværdig));
        }
    }
}
