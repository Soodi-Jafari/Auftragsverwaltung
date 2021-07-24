using Auftragsverwaltung.Data;
using Auftragsverwaltung.Data.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auftragsverwaltung.Web.Services
{
    public class AuftragService : IAuftragService
    {
        private readonly AuftragDbContext _auftragContext;
        public AuftragService(AuftragDbContext dbContext)
        {
            _auftragContext = dbContext;
        }
        public async Task<Auftrag> CreateAuftragAsync(Auftrag auftrag)
        {
            try
            {
                var ctx2 = new AuftragDbContext();
                auftrag.Betrag = this.BerechnungPreis(auftrag);
                var obj = await ctx2.Auftrag.AddAsync(auftrag);
                ctx2.SaveChanges();
                return obj.Entity;
            }
            catch (Exception ex)
            {
             //   _logger.LogError(ex, "Fehler beim Registrieren des Auftrag");
                return null;
            }
        }

        public async Task<Auftrag> GetAuftragAsync(int id)
        {
            var auftrag = await this._auftragContext.Auftrag.AsNoTracking().Include(x => x.Kunde).Include(a => a.Rechnung)
                                        .Include(a => a.AuftragsPositionen).ThenInclude(p => p.Artikel).FirstOrDefaultAsync(a => a.Id == id);
            return auftrag;
        }

        public async Task<IEnumerable<Auftrag>> GetAuftragOverviewAsync(DateTime? from = null, DateTime? till = null)
        {
            var auftrags = await this._auftragContext.Auftrag.AsNoTracking().Include(x => x.Kunde)
                                       .Where(x => (!from.HasValue || x.Datum >= from) && (!till.HasValue || x.Datum <= till))
                                       .ToListAsync();
            return auftrags;
        }

        public async Task<Auftrag> UpdateAuftragAsync(Auftrag auftrag)
        {
            try
            {
                var aftg = await this._auftragContext.Auftrag.AsNoTracking().Include(a => a.AuftragsPositionen).FirstOrDefaultAsync(a => a.Id == auftrag.Id);
                if (aftg != null)
                {
                    aftg.Datum = auftrag.Datum;
                    aftg.Betrag = this.BerechnungPreis(auftrag);
                    this.UpdateAuftragPositions(aftg, auftrag);
                    this._auftragContext.Update(aftg);
                    this._auftragContext.SaveChanges();
                    return aftg;
                }
                return null;
            }
            catch (Exception ex)
            {
                //  _logger.LogError(ex, "Fehler beim Bearbeiten des Auftrag");
                return null;
            }
        }

        private decimal BerechnungPreis(Auftrag auftrag)
        {
            decimal preis = 0;
            foreach (var pos in auftrag.AuftragsPositionen)
            {
                var artikel = this._auftragContext.Artikel.FirstOrDefault(a => a.Id == pos.ArtikelId);
                var netto = artikel.PreisNetto ?? 0;
                decimal brutto = netto + (netto * artikel.MwstSatz) / 100;
                preis += brutto * pos.Menge;
            }

            return preis;
        }

        private void UpdateAuftragPositions(Auftrag dbAuftrag,Auftrag auftrag)
        {
            foreach (var pos in auftrag.AuftragsPositionen)
            {
                var ap = dbAuftrag.AuftragsPositionen.FirstOrDefault(p => p.Id == pos.Id);
                if (ap == null)
                    _auftragContext.AuftragsPositionen.Add(pos);
                else
                    ap = pos;
            }
            var dellist = new List<AuftragsPositionen>();
            dellist = dbAuftrag.AuftragsPositionen.ToList();
            foreach (var item in dellist)
            {
                var ap = auftrag.AuftragsPositionen.FirstOrDefault(p => p.Id == item.Id);
                if (ap == null)
                {
                    _auftragContext.AuftragsPositionen.Remove(item);
                }
            }
        }
    }
}
