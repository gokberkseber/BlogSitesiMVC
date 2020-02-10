namespace BlogSitesiMVC.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BlogDBContext : DbContext
    {
        public BlogDBContext()
            : base("name=BlogDBContext")
        {
        }

        public virtual DbSet<Etiket> Etiket { get; set; }
        public virtual DbSet<Kategori> Kategori { get; set; }
        public virtual DbSet<Kullanici> Kullanici { get; set; }
        public virtual DbSet<Makale> Makale { get; set; }
        public virtual DbSet<Resim> Resim { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Yazar> Yazar { get; set; }
        public virtual DbSet<Yorum> Yorum { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Etiket>()
                .HasMany(e => e.Makale)
                .WithMany(e => e.Etiket)
                .Map(m => m.ToTable("MakaleEtiket").MapLeftKey("EtiketID").MapRightKey("MakaleID"));

            modelBuilder.Entity<Kategori>()
                .HasMany(e => e.Makale)
                .WithRequired(e => e.Kategori)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kullanici>()
                .HasMany(e => e.Yazar)
                .WithMany(e => e.Kullanici)
                .Map(m => m.ToTable("YazarTakip").MapLeftKey("KullaniciID").MapRightKey("YazarID"));

            modelBuilder.Entity<Makale>()
                .HasMany(e => e.Resim1)
                .WithOptional(e => e.Makale1)
                .HasForeignKey(e => e.MakaleID);

            modelBuilder.Entity<Makale>()
                .HasMany(e => e.Yorum)
                .WithRequired(e => e.Makale)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Resim>()
                .HasMany(e => e.Makale)
                .WithOptional(e => e.Resim)
                .HasForeignKey(e => e.ResimID);

            modelBuilder.Entity<Yazar>()
                .HasMany(e => e.Makale)
                .WithRequired(e => e.Yazar)
                .WillCascadeOnDelete(false);
        }
    }
}
