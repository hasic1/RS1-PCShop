
using Microsoft.EntityFrameworkCore;
using PCWebShop.Core.Infrastructure;
using PCWebShop.Core.Infrastructure.Enums;
using PCWebShop.Core.Interfaces;
using PCWebShop.Data;
using PCWebShop.Database;
using System;
using PCWebShop.Helper;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PCWebShop.Helper.AutentifikacijaAutorizacija;
using Microsoft.AspNetCore.Mvc;
using PCWebShop.Helper;
using PCWebShop.Modul0_Autentifikacija.Models;
using System.Linq.Expressions;
using PCWebShop.ViewModels;
using PCWebShop.Extensions;

namespace PCWebShop.Core.Services
{
    public class ObavjestService : IObavjestService   
    {
        private readonly Context _context;

        public ObavjestService(Context context)
        {
            this._context = context;
        }

        private Expression<Func<Obavjest, ObavjestVM>> GetMapperFromObavjestToObavjestiVM()
        {
            return x => new ObavjestVM
            {
                Content = x.Content,
                DateRead = x.DateRead,
                Deleted = x.Deleted,
                ID = x.ID,
                TipObavjesti = x.TipObavjesti,
                Read = x.Read,
                KorisnikId = x.KorisnikId,
                SendOnDate = x.SendOnDate,
                Korisnik=x.Korisnik,
                Seen = x.Seen
            };
        }

        public async Task CreateBirthdayNotifications()
        {
            //var clientsRoles = await _context.KorisnickiNalog.Where(x => x.isKupac == true).ToListAsync();

            var clients = await _context.Korisnik.ToListAsync();

            var today = DateTime.Now;
            var hours = new TimeSpan(12, 00, 00);
            today = today.Date + hours; 

            using var transaction = await _context.Database.BeginTransactionAsync();
            {
                try
                {
                    foreach (var client in clients)
                    {
                        if (client.DatumRodjenja.Month == DateTime.Now.Month && client.DatumRodjenja.Day == DateTime.Now.Day)
                        {

                            var obavjest = new Obavjest();
                            obavjest.Content = $"Sretan rođendan želi Vam vaš PcShop";
                            obavjest.SendOnDate = today;
                            obavjest.KorisnikId = client.id;                            
                            obavjest.TipObavjesti = TipObavjesti.App;

                            await _context.AddAsync(obavjest);
                        }
                    }

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw;
                }


            }

        }
        public async Task<Message> GetObavjestByUserIdAsMessageAsync(int id, CancellationToken cancellationToken)
        {
            var user = _context.Korisnik.Where(x => x.id == id).FirstOrDefault();

           

            var notifications = await _context.Obavjest.Where(x => x.KorisnikId == user.id && !x.Deleted && x.TipObavjesti == TipObavjesti.App && x.SendOnDate < DateTime.Now)
                .Select(GetMapperFromObavjestToObavjestiVM())
                .OrderByDescending(x=>x.ID)
                .ToListAsync(cancellationToken);

           

           
            return new Message
            {
                Data = notifications,
                Info = "Notifications returned successfully!",
                IsValid = true,
                Status = ExceptionCodeEnum.Success
            };
        }

    }
}
