using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AndenMonumentApp.Common;
using AndenMonumentApp.Model;

namespace AndenMonumentApp.ViewModel
{
    public class MonumentViewModel
    {
        public static GeneriskSingleton<Monument> monumentSingleton; 
        public ICommand opretMonumentCommand;
        public Handler Handler { get; set; }


        public static ObservableCollection<Monument> MonumentCollection
        {
            get { return monumentSingleton.Collection; }
            set { monumentSingleton.Collection = value; }
        }

        public ICommand OpretMonument
        {
            get
            {
                opretMonumentCommand = new RelayCommand(Handler.OpretMonument);
                return
                    opretMonumentCommand;
            }
            set { opretMonumentCommand = value; }

        }
    }
}
