using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonumentApp.Model
{
    class MonumentSingleton
    {
        private static MonumentSingleton instance = new MonumentSingleton();

        public static MonumentSingleton Instance
        {
            get { return instance; }
        }

        public ObservableCollection<Monument> Monumenter { get; set; }

        private MonumentSingleton()
        {
            Monumenter = new ObservableCollection<Monument>();
            Monument m1 = new Monument("430", "Frederik den store", "Poppelvej 12", "B");
            Monument m2 = new Monument("450", "Avekat", "Voldvej 12", "C");
            Monument m3 = new Monument("451", "Skaleaekw", "Hejvej 12", "A");
            Monumenter.Add(m1);
            Monumenter.Add(m2);
            Monumenter.Add(m3);
        }

        public void Add(string GlobalId, string Navn, String Adresse, string Bevaringsværdig)
        {
            Monumenter.Add(new Monument(GlobalId, Navn, Adresse, Bevaringsværdig));
        }
    }
}
