using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Intense.Presentation;
using MonumentApp.Annotations;
using MonumentApp.Handler;
using MonumentApp.Model;

namespace MonumentApp.ViewModel
{
   public class OpretSkadeViewModel : INotifyPropertyChanged
    {
        public ICommand CreateCommand { get; set; }
        public MonumentHandler MonumentHandler { get; set; }
        public PostNrTabel postNrTabel => StaticObjects.SelectedPostNr;
        public MonumentOversigt monumentOversigt => StaticObjects.SelectedMonumenter;
        public PlaceringsTyper placeringsTyper => StaticObjects.SelectedPlaceringsTyper;
        public PlaceringsOversigt placeringsOversigt => StaticObjects.SelectedPlaceringsOversigt;
        public MonumentTyper monumentTyper => StaticObjects.SelectedMonumentTyper;
        public MaterialeTyper materialeTyper => StaticObjects.SelectedMaterialeTyper;

       // public OpretSkadeViewModel()
       // {
       //     MonumentHandler = new MonumentHandler();
       //     NySkadeOversigt = new SkadeOversigt();
       //     CreateCommand = new RelayCommand(OpretSkade);
       // }

       //public void OpretSkade()
       //{
       //    MonumentHandler.OpretSkade();
       //}


        public event PropertyChangedEventHandler PropertyChanged;

       [NotifyPropertyChangedInvocator]
       protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
       {
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
       }
    }
}
