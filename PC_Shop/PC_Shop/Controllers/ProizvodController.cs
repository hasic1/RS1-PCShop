using Microsoft.AspNetCore.Mvc;
using PC_Shop_classLibrary.Database;
using PC_Shop_classLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Shop.Dal.Controllers
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
                    Snizen = p.Snizen
                }).AsQueryable();
            return data.Take(100).ToList();
        }
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(_context.Proizvod.FirstOrDefault(p => p.ProizvodID == id));
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

            return Ok(newProizvod.ProizvodID);

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
    }
}
