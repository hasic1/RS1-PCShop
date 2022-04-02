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
    public class ProizvodjacController : ControllerBase
    {
        private readonly Context _context;

        public ProizvodjacController(Context context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult Add([FromBody] ProizvodjacAddVM x)
        {
            var newProizvodjac = new Proizvodjac
            {
                NazivProizvodjaca=x.NazivProizvodjaca,
                SjedisteID=x.SjedisteID,
            };
            _context.Add(newProizvodjac);
            _context.SaveChanges();

            return Ok(newProizvodjac.ID);

        }
    }
}
