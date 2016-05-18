namespace MonumentConsole
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public virtual DbSet<MaterialeOversigt> MaterialeOversigts { get; set; }
        public virtual DbSet<MaterialeTyper> MaterialeTypers { get; set; }
        public virtual DbSet<MonumentOversigt> MonumentOversigts { get; set; }
        public virtual DbSet<MonumentTypeOversigt> MonumentTypeOversigts { get; set; }
        public virtual DbSet<MonumentTyper> MonumentTypers { get; set; }
        public virtual DbSet<PlaceringsOversigt> PlaceringsOversigts { get; set; }
        public virtual DbSet<PlaceringsTyper> PlaceringsTypers { get; set; }
        public virtual DbSet<PostNrTabel> PostNrTabels { get; set; }
        public virtual DbSet<SkadeOversigt> SkadeOversigts { get; set; }
        public virtual DbSet<SkadeTyper> SkadeTypers { get; set; }

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
                .HasMany(e => e.SkadeOversigts)
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
                .HasMany(e => e.SkadeOversigts)
                .WithRequired(e => e.SkadeTyper)
                .WillCascadeOnDelete(false);
        }
    }
}
