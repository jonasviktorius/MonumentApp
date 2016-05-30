using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonumentApp.Model
{
    public class MonumentTypeOversigt
    {
        public int MonumentType_Id { get; set; }
        public int Global_Id { get; set; }
    }
}

  