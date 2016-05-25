using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonumentApp.Model;
using MonumentApp.ViewModel;

namespace MonumentApp.Handler
{
    class MonumentOversigtHandler
    {
        private MonumentOversigtViewModel monumentOversigt;

        public MonumentOversigtViewModel MonumentOversigtViewModel { get; set; }

        public MonumentOversigtHandler(MonumentOversigtViewModel monumentViewModel)
        {
            MonumentOversigtViewModel = monumentOversigt;
        }

        public void OpretMonumentOversigt()
        {
            MonumentOversigt monumentOversigt = new MonumentOversigt();
            
        }
    }
}
 
 