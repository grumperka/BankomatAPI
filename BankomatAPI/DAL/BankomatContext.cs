using BibliotekaKlas;
using BibliotekaKlas.Classes;
using Microsoft.EntityFrameworkCore;

namespace BankomatAPI.DAL
{
    public class BankomatContext: DbContext
    {
        public string Key { get; set; }

        public BankomatContext(DbContextOptions options) :
            base(options)
        {
            this.Key = "bankomatAplikacjaDotNetApiHash32";
        }

        public DbSet<Banknot> Banknots { get; set; }

        public DbSet<KartaKredytowa> KartaKredytowas { get; set; }

        public DbSet<Konto> Kontos { get; set; }

        public DbSet<Portfel> Portfels { get; set; }

        public DbSet<Wlasciciel> Wlasciciels { get; set; }

        public DbSet<Bankomat> Bankomats { get; set; }

        public DbSet<Transakcja> Transakcjas { get; set; }

        public DbSet<Przelew> Przelews { get; set; }

        public DbSet<Moneta> Monetas { get; set; }

        public DbSet<Automat> Automats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Banknot>().ToTable("Banknots");
            modelBuilder.Entity<Moneta>().ToTable("Monetas");
            modelBuilder.Entity<Wlasciciel>().ToTable("Wlasciciels");
            modelBuilder.Entity<Konto>().ToTable("Kontos");
            modelBuilder.Entity<KartaKredytowa>().ToTable("KartaKredytowas");
            modelBuilder.Entity<Portfel>().ToTable("Portfels");
            modelBuilder.Entity<Bankomat>().ToTable("Bankomats");
            modelBuilder.Entity<Automat>().ToTable("Automats");
            modelBuilder.Entity<Transakcja>().ToTable("Transakcjas");
            modelBuilder.Entity<Przelew>().ToTable("Przelews");
        }
    }
}
