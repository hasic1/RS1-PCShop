using Microsoft.AspNetCore.Mvc;
using PC_Shop_classLibrary.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PC_Shop.Dal.Helper;
namespace PC_Shop.Dal.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AutentifikacijaController:ControllerBase
    {
        private readonly Context _context;

        public AutentifikacijaController(Context context)
        {
            _context = context;
        }
        public class LoginVM
        {
            public string KorisnickoIme { get; set; }
            public string Lozinka { get; set; }
        }

        [HttpPost]
        public AutentifikacijaToken Login([FromBody] LoginVM x)
        {
            //provjera logina
           
            KorisnickiNalog logiraniKorisnik = _context.KorisnickiNalog.Where(k => k.korisnickoIme!=null && k.korisnickoIme == x.KorisnickoIme && k.Lozinka == x.Lozinka)
                .SingleOrDefault();

            if (logiraniKorisnik == null)
            {
                //pogresan user name i pasword
                return null;
            }
            //generisati random string
            string randomString = TokenGenerate.Generate(10);

            //dodati novi zapis u tabelu Autentifikacija token za korisnikID i randomString
            var newAutentifikacijaToken = new AutentifikacijaToken()
            {
                IPAdresa = Request.HttpContext.Connection.RemoteIpAddress?.ToString(),
                vrijednost = randomString,
                KorisnickiNalog = logiraniKorisnik,
                VrijemeEvidentiranja = DateTime.Now
            };
            _context.Add(newAutentifikacijaToken);
            _context.SaveChanges();

            //vratiti token string
            return newAutentifikacijaToken;
        }
    }
}
