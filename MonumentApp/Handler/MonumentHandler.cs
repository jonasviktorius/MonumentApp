using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonumentApp.Model;
using MonumentApp.ViewModel;

namespace MonumentApp.Handler
{
    class MonumentHandler
    {
        public MonumentViewModel MonumentViewModel { get; set; }

        public MonumentHandler(MonumentViewModel monumentViewModel)
        {
            MonumentViewModel = monumentViewModel;
        }

        public void OpretMonument()
        {
            Monument monument = new Monument();
            monument.
        }
    }
}
