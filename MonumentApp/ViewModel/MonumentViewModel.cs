using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MonumentApp.Annotations;
using MonumentApp.Model;

namespace MonumentApp.ViewModel
{
    class MonumentViewModel : INotifyPropertyChanged
    {
        public MonumentSingleton MonumentSingleton  { get; set; }

        public MonumentViewModel()
        {
            MonumentSingleton = MonumentSingleton.Instance;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
