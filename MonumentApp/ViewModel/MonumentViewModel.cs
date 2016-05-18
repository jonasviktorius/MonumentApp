using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MonumentApp.Common;
using MonumentApp.Handler;
//using MonumentApp.Annotations;
using MonumentApp.Model;

namespace MonumentApp.ViewModel
{
    class MonumentViewModel : INotifyPropertyChanged
    {
        public MonumentSingleton MonumentSingleton  { get; set; }
        public ICommand CreateCommand { get; set; }
        public MonumentHandler MonumentHandler { get; set; }

        public MonumentViewModel()
        {
            MonumentSingleton = MonumentSingleton.Instance;
            MonumentHandler = new MonumentHandler(this);
            //NytMonument = new Monument();
            CreateCommand = new RelayCommand(MonumentHandler.OpretMonument);
        }

        //[NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
