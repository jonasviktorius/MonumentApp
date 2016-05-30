namespace WebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PostNrTabel")]
    public partial class PostNrTabel
    {
         public PostNrTabel()
        {
            MonumentOversigt = new HashSet<MonumentOversigt>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PostNr { get; set; }

        [StringLength(250)]
        public string ByNavn { get; set; }

         public virtual ICollection<MonumentOversigt> MonumentOversigt { get; set; }
    }
}
