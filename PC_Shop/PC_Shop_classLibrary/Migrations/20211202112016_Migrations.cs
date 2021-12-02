using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PC_Shop_classLibrary.Migrations
{
    public partial class Migrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banka",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivBanke = table.Column<string>(nullable: true),
                    KontaktTel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banka", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dostavljac",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivDostave = table.Column<string>(nullable: true),
                    Adresa = table.Column<string>(nullable: true),
                    KontaktTelefon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dostavljac", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Drzava",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzava", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Kategorija",
                columns: table => new
                {
                    KategorijaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivKategorije = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorija", x => x.KategorijaID);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    Spol = table.Column<string>(nullable: true),
                    DatumRodjenja = table.Column<DateTime>(nullable: false),
                    DrzavaID = table.Column<int>(nullable: false),
                    Pretplacen = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Korisnik_Drzava_DrzavaID",
                        column: x => x.DrzavaID,
                        principalTable: "Drzava",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proizvodjac",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivProizvodjaca = table.Column<string>(nullable: true),
                    SjedisteID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvodjac", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Proizvodjac_Drzava_SjedisteID",
                        column: x => x.SjedisteID,
                        principalTable: "Drzava",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Narudzba",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumKreireanja = table.Column<DateTime>(nullable: false),
                    NaruciocID = table.Column<int>(nullable: false),
                    DostavljacID = table.Column<int>(nullable: false),
                    Aktivna = table.Column<bool>(nullable: false),
                    Potvrdjena = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Narudzba", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Narudzba_Dostavljac_DostavljacID",
                        column: x => x.DostavljacID,
                        principalTable: "Dostavljac",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Narudzba_Korisnik_NaruciocID",
                        column: x => x.NaruciocID,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Oglas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naslov = table.Column<string>(nullable: true),
                    Sadrzaj = table.Column<string>(nullable: true),
                    BrojPozicja = table.Column<int>(nullable: false),
                    Lokacija = table.Column<string>(nullable: true),
                    DatumObjave = table.Column<DateTime>(nullable: false),
                    TrajanjeOglasa = table.Column<int>(nullable: false),
                    DatumIsteka = table.Column<DateTime>(nullable: false),
                    AutorOglasaId = table.Column<int>(nullable: true),
                    Aktivan = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oglas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Oglas_Korisnik_AutorOglasaId",
                        column: x => x.AutorOglasaId,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naslov = table.Column<string>(nullable: true),
                    Sadrzaj = table.Column<string>(nullable: true),
                    KorisnikID = table.Column<int>(nullable: false),
                    LokacijaSlike = table.Column<string>(nullable: true),
                    DatumObjave = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Post_Korisnik_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Racun",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikID = table.Column<int>(nullable: false),
                    BankaID = table.Column<int>(nullable: false),
                    BrojRacuna = table.Column<string>(nullable: true),
                    DatumAktiviranjaRacuna = table.Column<DateTime>(nullable: false),
                    StanjeRacuna = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racun", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Racun_Banka_BankaID",
                        column: x => x.BankaID,
                        principalTable: "Banka",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Racun_Korisnik_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proizvod",
                columns: table => new
                {
                    ProizvodID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivProizvoda = table.Column<string>(nullable: true),
                    Cijena = table.Column<double>(nullable: false),
                    Kolicina = table.Column<int>(nullable: false),
                    Opis = table.Column<string>(nullable: true),
                    KategorijaID = table.Column<int>(nullable: false),
                    LokacijaSlike = table.Column<string>(nullable: true),
                    Snizen = table.Column<bool>(nullable: false),
                    ProizvodjacID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvod", x => x.ProizvodID);
                    table.ForeignKey(
                        name: "FK_Proizvod_Kategorija_KategorijaID",
                        column: x => x.KategorijaID,
                        principalTable: "Kategorija",
                        principalColumn: "KategorijaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Proizvod_Proizvodjac_ProizvodjacID",
                        column: x => x.ProizvodjacID,
                        principalTable: "Proizvodjac",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KorisnikOglas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikID = table.Column<int>(nullable: false),
                    OglasID = table.Column<int>(nullable: false),
                    DatumPrijave = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnikOglas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KorisnikOglas_Korisnik_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KorisnikOglas_Oglas_OglasID",
                        column: x => x.OglasID,
                        principalTable: "Oglas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NarudzbaStavka",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProizvodID = table.Column<int>(nullable: true),
                    PropizvodID = table.Column<int>(nullable: false),
                    NarudzbaID = table.Column<int>(nullable: false),
                    Kolicina = table.Column<int>(nullable: false),
                    Cijena = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NarudzbaStavka", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NarudzbaStavka_Narudzba_NarudzbaID",
                        column: x => x.NarudzbaID,
                        principalTable: "Narudzba",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NarudzbaStavka_Proizvod_ProizvodID",
                        column: x => x.ProizvodID,
                        principalTable: "Proizvod",
                        principalColumn: "ProizvodID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Recenzija",
                columns: table => new
                {
                    RecenzijaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ocjena = table.Column<int>(nullable: false),
                    Komentar = table.Column<string>(nullable: true),
                    ProizvodId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recenzija", x => x.RecenzijaID);
                    table.ForeignKey(
                        name: "FK_Recenzija_Proizvod_ProizvodId",
                        column: x => x.ProizvodId,
                        principalTable: "Proizvod",
                        principalColumn: "ProizvodID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_DrzavaID",
                table: "Korisnik",
                column: "DrzavaID");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikOglas_KorisnikID",
                table: "KorisnikOglas",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikOglas_OglasID",
                table: "KorisnikOglas",
                column: "OglasID");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_DostavljacID",
                table: "Narudzba",
                column: "DostavljacID");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_NaruciocID",
                table: "Narudzba",
                column: "NaruciocID");

            migrationBuilder.CreateIndex(
                name: "IX_NarudzbaStavka_NarudzbaID",
                table: "NarudzbaStavka",
                column: "NarudzbaID");

            migrationBuilder.CreateIndex(
                name: "IX_NarudzbaStavka_ProizvodID",
                table: "NarudzbaStavka",
                column: "ProizvodID");

            migrationBuilder.CreateIndex(
                name: "IX_Oglas_AutorOglasaId",
                table: "Oglas",
                column: "AutorOglasaId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_KorisnikID",
                table: "Post",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Proizvod_KategorijaID",
                table: "Proizvod",
                column: "KategorijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Proizvod_ProizvodjacID",
                table: "Proizvod",
                column: "ProizvodjacID");

            migrationBuilder.CreateIndex(
                name: "IX_Proizvodjac_SjedisteID",
                table: "Proizvodjac",
                column: "SjedisteID");

            migrationBuilder.CreateIndex(
                name: "IX_Racun_BankaID",
                table: "Racun",
                column: "BankaID");

            migrationBuilder.CreateIndex(
                name: "IX_Racun_KorisnikID",
                table: "Racun",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Recenzija_ProizvodId",
                table: "Recenzija",
                column: "ProizvodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KorisnikOglas");

            migrationBuilder.DropTable(
                name: "NarudzbaStavka");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Racun");

            migrationBuilder.DropTable(
                name: "Recenzija");

            migrationBuilder.DropTable(
                name: "Oglas");

            migrationBuilder.DropTable(
                name: "Narudzba");

            migrationBuilder.DropTable(
                name: "Banka");

            migrationBuilder.DropTable(
                name: "Proizvod");

            migrationBuilder.DropTable(
                name: "Dostavljac");

            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.DropTable(
                name: "Kategorija");

            migrationBuilder.DropTable(
                name: "Proizvodjac");

            migrationBuilder.DropTable(
                name: "Drzava");
        }
    }
}
