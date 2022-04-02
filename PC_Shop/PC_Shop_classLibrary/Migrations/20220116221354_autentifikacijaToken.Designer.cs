﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PC_Shop_classLibrary.Database;

namespace PC_Shop_classLibrary.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20220116221354_autentifikacijaToken")]
    partial class autentifikacijaToken
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PC_Shop_classLibrary.Database.AutentifikacijaToken", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("IPAdresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KorisnickiNalogID")
                        .HasColumnType("int");

                    b.Property<DateTime>("VrijemeEvidentiranja")
                        .HasColumnType("datetime2");

                    b.Property<string>("vrijednost")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("KorisnickiNalogID");

                    b.ToTable("AutentifikacijaToken");
                });

            modelBuilder.Entity("PC_Shop_classLibrary.Database.Banka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("KontaktTel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NazivBanke")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Banka");
                });

            modelBuilder.Entity("PC_Shop_classLibrary.Database.BankovniRacun", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BankaID")
                        .HasColumnType("int");

                    b.Property<string>("BrojRacuna")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatumAktiviranjaRacuna")
                        .HasColumnType("datetime2");

                    b.Property<int>("KorisnikID")
                        .HasColumnType("int");

                    b.Property<double>("StanjeRacuna")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex("BankaID");

                    b.HasIndex("KorisnikID");

                    b.ToTable("Racun");
                });

            modelBuilder.Entity("PC_Shop_classLibrary.Database.Dostavljac", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KontaktTelefon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NazivDostave")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Dostavljac");
                });

            modelBuilder.Entity("PC_Shop_classLibrary.Database.Drzava", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Drzava");
                });

            modelBuilder.Entity("PC_Shop_classLibrary.Database.Kategorija", b =>
                {
                    b.Property<int>("KategorijaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NazivKategorije")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KategorijaID");

                    b.ToTable("Kategorija");
                });

            modelBuilder.Entity("PC_Shop_classLibrary.Database.KorisnickiNalog", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lozinka")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("korisnickoIme")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("KorisnickiNalog");

                    b.HasDiscriminator<string>("Discriminator").HasValue("KorisnickiNalog");
                });

            modelBuilder.Entity("PC_Shop_classLibrary.Database.KorisnikOglas", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumPrijave")
                        .HasColumnType("datetime2");

                    b.Property<int>("KorisnikID")
                        .HasColumnType("int");

                    b.Property<int>("OglasID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("KorisnikID");

                    b.HasIndex("OglasID");

                    b.ToTable("KorisnikOglas");
                });

            modelBuilder.Entity("PC_Shop_classLibrary.Database.Narudzba", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Aktivna")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DatumKreiranja")
                        .HasColumnType("datetime2");

                    b.Property<int>("DostavljacID")
                        .HasColumnType("int");

                    b.Property<int>("NaruciocID")
                        .HasColumnType("int");

                    b.Property<bool>("Potvrdjena")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("DostavljacID");

                    b.HasIndex("NaruciocID");

                    b.ToTable("Narudzba");
                });

            modelBuilder.Entity("PC_Shop_classLibrary.Database.NarudzbaStavka", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Cijena")
                        .HasColumnType("float");

                    b.Property<int>("Kolicina")
                        .HasColumnType("int");

                    b.Property<int>("NarudzbaID")
                        .HasColumnType("int");

                    b.Property<int?>("ProizvodID")
                        .HasColumnType("int");

                    b.Property<int>("PropizvodID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("NarudzbaID");

                    b.HasIndex("ProizvodID");

                    b.ToTable("NarudzbaStavka");
                });

            modelBuilder.Entity("PC_Shop_classLibrary.Database.Oglas", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Aktivan")
                        .HasColumnType("bit");

                    b.Property<int?>("AutorOglasaID")
                        .HasColumnType("int");

                    b.Property<int>("BrojPozicja")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatumIsteka")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatumObjave")
                        .HasColumnType("datetime2");

                    b.Property<string>("Lokacija")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naslov")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sadrzaj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrajanjeOglasa")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AutorOglasaID");

                    b.ToTable("Oglas");
                });

            modelBuilder.Entity("PC_Shop_classLibrary.Database.Post", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AutorPostaID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatumObjave")
                        .HasColumnType("datetime2");

                    b.Property<int>("KorisnikID")
                        .HasColumnType("int");

                    b.Property<string>("LokacijaSlike")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naslov")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sadrzaj")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("AutorPostaID");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("PC_Shop_classLibrary.Database.Proizvod", b =>
                {
                    b.Property<int>("ProizvodID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Cijena")
                        .HasColumnType("float");

                    b.Property<int>("KategorijaID")
                        .HasColumnType("int");

                    b.Property<int>("Kolicina")
                        .HasColumnType("int");

                    b.Property<string>("LokacijaSlike")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NazivProizvoda")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProizvodjacID")
                        .HasColumnType("int");

                    b.Property<bool>("Snizen")
                        .HasColumnType("bit");

                    b.HasKey("ProizvodID");

                    b.HasIndex("KategorijaID");

                    b.HasIndex("ProizvodjacID");

                    b.ToTable("Proizvod");
                });

            modelBuilder.Entity("PC_Shop_classLibrary.Database.Proizvodjac", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NazivProizvodjaca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SjedisteID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("SjedisteID");

                    b.ToTable("Proizvodjac");
                });

            modelBuilder.Entity("PC_Shop_classLibrary.Database.Recenzija", b =>
                {
                    b.Property<int>("RecenzijaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Komentar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ocjena")
                        .HasColumnType("int");

                    b.Property<int>("ProizvodId")
                        .HasColumnType("int");

                    b.HasKey("RecenzijaID");

                    b.HasIndex("ProizvodId");

                    b.ToTable("Recenzija");
                });

            modelBuilder.Entity("PC_Shop_classLibrary.Database.Administrator", b =>
                {
                    b.HasBaseType("PC_Shop_classLibrary.Database.KorisnickiNalog");

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<int>("DrzavaID")
                        .HasColumnType("int");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Spol")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("DrzavaID");

                    b.HasDiscriminator().HasValue("Administrator");
                });

            modelBuilder.Entity("PC_Shop_classLibrary.Database.Korisnik", b =>
                {
                    b.HasBaseType("PC_Shop_classLibrary.Database.KorisnickiNalog");

                    b.Property<DateTime?>("DatumRodjenja")
                        .HasColumnName("Korisnik_DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DrzavaID")
                        .HasColumnName("Korisnik_DrzavaID")
                        .HasColumnType("int");

                    b.Property<string>("Ime")
                        .HasColumnName("Korisnik_Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Pretplacen")
                        .HasColumnType("bit");

                    b.Property<string>("Prezime")
                        .HasColumnName("Korisnik_Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Spol")
                        .HasColumnName("Korisnik_Spol")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("DrzavaID");

                    b.HasDiscriminator().HasValue("Korisnik");
                });

            modelBuilder.Entity("PC_Shop_classLibrary.Database.AutentifikacijaToken", b =>
                {
                    b.HasOne("PC_Shop_classLibrary.Database.KorisnickiNalog", "KorisnickiNalog")
                        .WithMany()
                        .HasForeignKey("KorisnickiNalogID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PC_Shop_classLibrary.Database.BankovniRacun", b =>
                {
                    b.HasOne("PC_Shop_classLibrary.Database.Banka", "Banka")
                        .WithMany()
                        .HasForeignKey("BankaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PC_Shop_classLibrary.Database.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PC_Shop_classLibrary.Database.KorisnikOglas", b =>
                {
                    b.HasOne("PC_Shop_classLibrary.Database.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PC_Shop_classLibrary.Database.Oglas", "Oglas")
                        .WithMany()
                        .HasForeignKey("OglasID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PC_Shop_classLibrary.Database.Narudzba", b =>
                {
                    b.HasOne("PC_Shop_classLibrary.Database.Dostavljac", "Dostavljac")
                        .WithMany()
                        .HasForeignKey("DostavljacID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PC_Shop_classLibrary.Database.Korisnik", "Narucioc")
                        .WithMany()
                        .HasForeignKey("NaruciocID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PC_Shop_classLibrary.Database.NarudzbaStavka", b =>
                {
                    b.HasOne("PC_Shop_classLibrary.Database.Narudzba", "Narudzba")
                        .WithMany("NarudzbaStavke")
                        .HasForeignKey("NarudzbaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PC_Shop_classLibrary.Database.Proizvod", "Proizvod")
                        .WithMany()
                        .HasForeignKey("ProizvodID");
                });

            modelBuilder.Entity("PC_Shop_classLibrary.Database.Oglas", b =>
                {
                    b.HasOne("PC_Shop_classLibrary.Database.Administrator", "AutorOglasa")
                        .WithMany()
                        .HasForeignKey("AutorOglasaID");
                });

            modelBuilder.Entity("PC_Shop_classLibrary.Database.Post", b =>
                {
                    b.HasOne("PC_Shop_classLibrary.Database.Administrator", "AutorPosta")
                        .WithMany()
                        .HasForeignKey("AutorPostaID");
                });

            modelBuilder.Entity("PC_Shop_classLibrary.Database.Proizvod", b =>
                {
                    b.HasOne("PC_Shop_classLibrary.Database.Kategorija", "Kategorija")
                        .WithMany()
                        .HasForeignKey("KategorijaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PC_Shop_classLibrary.Database.Proizvodjac", "Proizvodjac")
                        .WithMany()
                        .HasForeignKey("ProizvodjacID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PC_Shop_classLibrary.Database.Proizvodjac", b =>
                {
                    b.HasOne("PC_Shop_classLibrary.Database.Drzava", "Sjediste")
                        .WithMany()
                        .HasForeignKey("SjedisteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PC_Shop_classLibrary.Database.Recenzija", b =>
                {
                    b.HasOne("PC_Shop_classLibrary.Database.Proizvod", "Proizvod")
                        .WithMany()
                        .HasForeignKey("ProizvodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PC_Shop_classLibrary.Database.Administrator", b =>
                {
                    b.HasOne("PC_Shop_classLibrary.Database.Drzava", "Drzava")
                        .WithMany()
                        .HasForeignKey("DrzavaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PC_Shop_classLibrary.Database.Korisnik", b =>
                {
                    b.HasOne("PC_Shop_classLibrary.Database.Drzava", "Drzava")
                        .WithMany()
                        .HasForeignKey("DrzavaID");
                });
#pragma warning restore 612, 618
        }
    }
}