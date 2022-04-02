using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PCWebShop.Data;
using PCWebShop.Database;
using PCWebShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCWebShop.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class KategorijaController : ControllerBase
    {
        private readonly Context _context;

        public KategorijaController(Context context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult Add([FromBody] KategorijaAddVM x)
        {

            var newKategorija = new Kategorija
            {

               NazivKategorije=x.NazivKategorije
            };
            _context.Add(newKategorija);
            _context.SaveChanges();

            return Ok(newKategorija.KategorijaID);

        }
    }
}
