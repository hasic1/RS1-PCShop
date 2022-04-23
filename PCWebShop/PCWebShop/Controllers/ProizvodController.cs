using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PCWebShop.Data;
using PCWebShop.Database;
using PCWebShop.Helper;
using PCWebShop.Helper.AutentifikacijaAutorizacija;
using PCWebShop.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PCWebShop.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProizvodController : ControllerBase
    {
        private readonly Context _context;

        public ProizvodController(Context context)
        {
            _context = context;
        }
        [HttpGet]
        public List<ProizvodVM> GetAll() {

            var data = _context.Proizvod.OrderBy(p => p.ProizvodID)
                .Select(p => new ProizvodVM()
                {
                    ProizvodID = p.ProizvodID,
                    NazivProizvoda = p.NazivProizvoda,
                    ProizvodjacID = p.ProizvodjacID,
                    Cijena = p.Cijena,
                    KategorijaID = p.KategorijaID,
                    Kolicina = p.Kolicina,
                    LokacijaSlike = p.LokacijaSlike,
                    Opis = p.Opis,
                    Snizen = p.Snizen,
                    Kategorija=p.Kategorija,
                    Proizvodjac=p.Proizvodjac
                }).AsQueryable();
            return data.Take(100).ToList();
        }
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(_context.Proizvod.Include(p => p.Kategorija).Include(p=>p.Proizvodjac).FirstOrDefault(p => p.ProizvodID == id)) ;
        }

        [HttpPost]
        public ActionResult Add([FromBody] ProizvodAddVM x) {

            var newProizvod = new Proizvod
            {                
                Cijena = x.Cijena,
                KategorijaID = x.KategorijaID,
                Kolicina = x.Kolicina,
                LokacijaSlike = x.LokacijaSlike,
                NazivProizvoda = x.NazivProizvoda,
                Opis = x.Opis,
                ProizvodjacID = x.ProizvodjacID,
                Snizen = x.Snizen                
            };
            _context.Add(newProizvod);
            _context.SaveChanges();

            return Get(newProizvod.ProizvodID);

        }
        [HttpPost("{id}")]
        public ActionResult Update(int id, [FromBody] ProizvodUpdateVM x)
        {
            Proizvod proizvod = _context.Proizvod.Where(p => p.ProizvodID == id).FirstOrDefault(p => p.ProizvodID == id);

            if (proizvod == null)
                return BadRequest("pogresan ID");

            proizvod.ProizvodjacID = x.ProizvodjacID;
            proizvod.Snizen = x.Snizen;
            proizvod.Opis = x.Opis;
            proizvod.NazivProizvoda = x.NazivProizvoda;
            proizvod.LokacijaSlike = x.LokacijaSlike;
            proizvod.Kolicina = x.Kolicina;
            proizvod.KategorijaID = x.KategorijaID;
            proizvod.Cijena = x.Cijena;


            _context.SaveChanges();
            return Get(id);
        }

        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            Proizvod proizvod = _context.Proizvod.Find(id);

            if (proizvod == null)
                return BadRequest("pogresan ID");

            _context.Remove(proizvod);

            _context.SaveChanges();
            return Ok(proizvod);
        }
        [HttpPost("{id}")]
        public ActionResult AddProfileImage(int id, [FromForm] ProizvodImageAddVM x)
        {
            try
            {
                Proizvod proizvod = _context.Proizvod.FirstOrDefault(s => s.ProizvodID == id);

                if (x.slika_proizvoda != null && proizvod != null)
                {                    
                    string ekstenzija = Path.GetExtension(x.slika_proizvoda.FileName);

                    var filename = $"{Guid.NewGuid()}{ekstenzija}";

                    x.slika_proizvoda.CopyTo(new FileStream(Config.SlikeFolder + filename, FileMode.Create));
                    proizvod.LokacijaSlike = Config.SlikeURL + filename;
                    _context.SaveChanges();
                }

                return Ok(proizvod);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ex.InnerException);
            }
        }
    }
}
