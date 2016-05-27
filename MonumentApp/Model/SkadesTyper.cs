using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonumentApp.Model
{
   
        public partial class SkadeTyper
        {
              public SkadeTyper()
            {
                SkadeOversigt = new HashSet<SkadeOversigt>();
            }
            public int SkadeType_Id { get; set; }
            public string SkadeType { get; set; }
            public virtual ICollection<SkadeOversigt> SkadeOversigt { get; set; }
        }
    }



