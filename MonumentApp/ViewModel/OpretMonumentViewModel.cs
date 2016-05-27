using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MonumentApp.Annotations;
using MonumentApp.Common;
using MonumentApp.Handler;
//using MonumentApp.Annotations;
using MonumentApp.Model;

namespace MonumentApp.ViewModel
{
    public class OpretMonumentViewModel : INotifyPropertyChanged
    {
        public string PostNrBinding
        {
            get { return monumentOversigt.PostNr.ToString(); }
            set
            {
                int postnr;
                if (int.TryParse(value, out postnr))
                    monumentOversigt.PostNr = postnr;
            } 
        }

        public MonumentSingleton MonumentSingleton { get; set; }
        public ICommand CreateCommand { get; set; }
        public MonumentHandler MonumentHandler { get; set; }
        public PostNrTabel postNrTabel => StaticObjects.SelectedPostNr;
        public MonumentOversigt monumentOversigt => StaticObjects.SelectedMonumenter;
        public PlaceringsTyper placeringsTyper => StaticObjects.SelectedPlaceringsTyper;
        public PlaceringsOversigt placeringsOversigt => StaticObjects.SelectedPlaceringsOversigt;
        public MonumentTyper monumentTyper => StaticObjects.SelectedMonumentTyper;
        public MaterialeTyper materialeTyper => StaticObjects.SelectedMaterialeTyper;

        public OpretMonumentViewModel()
        {
            MonumentSingleton = MonumentSingleton.Instance;
            MonumentHandler = new MonumentHandler();
            NytMonumentOversigt = new MonumentOversigt();
            CreateCommand = new RelayCommand(OpretMonument);

        }

        public void OpretMonument()
        {
            MonumentHandler.OpretMonument();
        }

        public MonumentOversigt NytMonumentOversigt { get; set; }

        //[NotifyPropertyChangedInvocator]

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
