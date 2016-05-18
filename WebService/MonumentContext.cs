namespace WebService
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MonumentContext : DbContext
    {
        public MonumentContext()
            : base("name=MonumentContext")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<MaterialeOversigt> MaterialeOversigt { get; set; }
        public virtual DbSet<MaterialeTyper> MaterialeTyper { get; set; }
        public virtual DbSet<MonumentOversigt> MonumentOversigt { get; set; }
        public virtual DbSet<MonumentTypeOversigt> MonumentTypeOversigt { get; set; }
        public virtual DbSet<MonumentTyper> MonumentTyper { get; set; }
        public virtual DbSet<PlaceringsOversigt> PlaceringsOversigt { get; set; }
        public virtual DbSet<PlaceringsTyper> PlaceringsTyper { get; set; }
        public virtual DbSet<PostNrTabel> PostNrTabel { get; set; }
        public virtual DbSet<SkadeOversigt> SkadeOversigt { get; set; }
        public virtual DbSet<SkadeTyper> SkadeTyper { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaterialeTyper>()
                .Property(e => e.MaterialeType)
                .IsUnicode(false);

            modelBuilder.Entity<MonumentOversigt>()
                .Property(e => e.Navn)
                .IsUnicode(false);

            modelBuilder.Entity<MonumentOversigt>()
                .Property(e => e.Adresse)
                .IsUnicode(false);

            modelBuilder.Entity<MonumentOversigt>()
                .Property(e => e.Note)
                .IsUnicode(false);

            modelBuilder.Entity<MonumentOversigt>()
                .Property(e => e.Bevaringsværdi)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MonumentOversigt>()
                .HasMany(e => e.SkadeOversigt)
                .WithRequired(e => e.MonumentOversigt)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MonumentTyper>()
                .Property(e => e.MonumentType)
                .IsUnicode(false);

            modelBuilder.Entity<PlaceringsTyper>()
                .Property(e => e.Placering)
                .IsUnicode(false);

            modelBuilder.Entity<PostNrTabel>()
                .Property(e => e.ByNavn)
                .IsUnicode(false);

            modelBuilder.Entity<SkadeTyper>()
                .Property(e => e.SkadeType)
                .IsUnicode(false);

            modelBuilder.Entity<SkadeTyper>()
                .HasMany(e => e.SkadeOversigt)
                .WithRequired(e => e.SkadeTyper)
                .WillCascadeOnDelete(false);
        }
    }
}
