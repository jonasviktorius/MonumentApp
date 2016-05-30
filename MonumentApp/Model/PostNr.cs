using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonumentApp.Model
{
    public partial class PostNrTabel
    {
            public PostNrTabel()
        {
            MonumentOversigt = new HashSet<MonumentOversigt>();
        }
        public int PostNr { get; set; }
        public string ByNavn { get; set; }

        public virtual ICollection<MonumentOversigt> MonumentOversigt { get; set; }
    }
}
