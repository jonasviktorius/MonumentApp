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

//using MonumentApp.Annotations;
using MonumentApp.Model;

namespace MonumentApp.ViewModel
{
    class MonumentOversigtViewModel : INotifyPropertyChanged
    {
        public MonumentOversigtSingleton _monumentOversigtSingleton;

        public MonumentOversigtSingleton MonumentOversigtSingleton
        {
            get { return _monumentOversigtSingleton; }
            set { _monumentOversigtSingleton = value; OnPropertyChanged(); }
        }

        private MonumentOversigt _newMonumentOversigt;

        public MonumentOversigt NewMonumentOversigt
        {

            get { return _newMonumentOversigt; }

            set { _newMonumentOversigt = value; OnPropertyChanged(); }
        }

        public MonumentOversigtViewModel()

        {
           MonumentOversigtSingleton = MonumentOversigtSingleton.Instance;
           NewMonumentOversigt = new MonumentOversigt();
        }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
    }
}
