using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonumentApp.Model
{
    public partial class SkadeOversigt
    {
       
        public int Skade_Id { get; set; }
        public int Global_Id { get; set; }
        public int SkadeType_Id { get; set; }
        public bool ErSkadenUdbedret { get; set; }
        public virtual MonumentOversigt MonumentOversigt { get; set; }
        public virtual SkadeTyper SkadeTyper { get; set; }
    }
}