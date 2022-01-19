using Microsoft.EntityFrameworkCore;
using PC_Shop_classLibrary.Database;

namespace PC_Shop_classLibrary.Database
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        { }
        public Context() { }
        public DbSet<Proizvod> Proizvod { get; set; }
        public DbSet<Kategorija> Kategorija { get; set; }
        public DbSet<Recenzija> Recenzija { get; set; }
        public DbSet<Oglas> Oglas { get; set; }
        public DbSet<KorisnikOglas> KorisnikOglas { get; set; }
        public DbSet<Drzava> Drzava { get; set; }
        public DbSet<Banka> Banka { get; set; }
        public DbSet<BankovniRacun> Racun { get; set; }
        public DbSet<Proizvodjac> Proizvodjac { get; set; }
        public DbSet<Dostavljac> Dostavljac { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Narudzba> Narudzba { get; set; }
        public DbSet<NarudzbaStavka> NarudzbaStavka { get; set; }
        public DbSet<KorisnickiNalog> KorisnickiNalog  { get; set; }
        public DbSet<Administrator> Administrator { get; set; }
        public DbSet<Korisnik> Korisnik { get; set; }
        public DbSet<AutentifikacijaToken> AutentifikacijaToken { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Korisnik>().ToTable("Korisnik");
            //modelBuilder.Entity<Administrator>().ToTable("Administrator");
        }

    }
}
