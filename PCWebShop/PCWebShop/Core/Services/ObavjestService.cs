using Microsoft.EntityFrameworkCore;
using PCWebShop.Core.Infrastructure.Enums;
using PCWebShop.Core.Interfaces;
using PCWebShop.Data;
using PCWebShop.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCWebShop.Core.Services
{
    public class ObavjestService :IObavjestService
    {
        private readonly Context _context;

        public ObavjestService(Context context)
        {
            this._context = context;
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
    }
}
