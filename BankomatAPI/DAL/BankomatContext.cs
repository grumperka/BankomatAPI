using BankomatAPI.Classes;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Banknot>().ToTable("Banknots");
            modelBuilder.Entity<Wlasciciel>().ToTable("Wlasciciels");
            modelBuilder.Entity<Konto>().ToTable("Kontos");
            modelBuilder.Entity<KartaKredytowa>().ToTable("KartaKredytowas");
            modelBuilder.Entity<Portfel>().ToTable("Portfels");
            modelBuilder.Entity<Bankomat>().ToTable("Bankomats");
        }
    }
}
