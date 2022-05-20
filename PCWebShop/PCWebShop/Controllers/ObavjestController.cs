using Microsoft.AspNetCore.Mvc;
using PCWebShop.Core.Interfaces;
using PCWebShop.Data;
using PCWebShop.Helper.AutentifikacijaAutorizacija;
using PCWebShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PCWebShop.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ObavjestController : ControllerBase
    {
        private readonly IObavjestService _oglasService;

        public readonly Context _context;

        public ObavjestController(IObavjestService oglasService, Context context)
        {
            _oglasService = oglasService;
            _context = context;
        }

        //[HttpGet]
        //public List<ObavjestVM> GetAll()
        //{
        //    var user = HttpContext.GetLoginInfo().korisnickiNalog;
               

        //    var data = _context.Obavjest.OrderByDescending(o=>o.ID)
        //        .Where(o=>o.KorisnikId == user.id)
        //        .Select(s => new ObavjestVM()
        //        {
        //            ID = s.ID,
        //            Content=s.Content,
        //            DateRead=s.DateRead,
        //            Deleted=s.Deleted,
        //            Korisnik=s.Korisnik,
        //            KorisnikId=s.KorisnikId,
        //            Read=s.Read,
        //            Seen=s.Seen,
        //            SendOnDate=s.SendOnDate,
        //            TipObavjesti=s.TipObavjesti
        //        }).AsQueryable();

        //    return data.Take(100).ToList();


        //}
        [HttpGet]
        public async Task<IActionResult> GetUserNotifications(int id, CancellationToken cancellationToken)
        {
            var result = await _oglasService.GetObavjestByUserIdAsMessageAsync(id, cancellationToken);

            if (!result.IsValid)
                return BadRequest();

            return Ok(result);
        }
    }
}
