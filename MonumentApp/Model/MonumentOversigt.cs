﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonumentApp.Model
{
   public class MonumentOversigt 
    {
  
        [Key]
        public int Global_Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Navn { get; set; }

        [Required]
        [StringLength(250)]
        public string Adresse { get; set; }

        public int? PostNr { get; set; }

        [StringLength(100)]
        public string Note { get; set; }

        [StringLength(1)]
        public string Bevaringsværdi { get; set; }

        public virtual PostNrTabel PostNrTabel { get; set; }

      
        public virtual ICollection<SkadeOversigt> SkadeOversigt { get; set; }

        public MonumentOversigt()
        {
            
        }
        public MonumentOversigt(string navn, string adresse, string bevaringsværdi)
        {
            Navn = navn;
            Adresse = adresse;
            Bevaringsværdi = bevaringsværdi;
        }
        

        public override string ToString()
        {
            return $"Navn: {Navn}, Adresse: {Adresse}, Bevaringsværdig: {Bevaringsværdi}";
        }
    }
}