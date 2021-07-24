using Auftragsverwaltung.Data;
using Auftragsverwaltung.Data.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auftragsverwaltung.Web.Services
{
    public class ArtikelService : IArtikelService
    {
        private readonly AuftragDbContext _auftragContext;
        public ArtikelService(AuftragDbContext dbContext)
        {
            _auftragContext = dbContext;
        }
        public async Task<IEnumerable<Artikel>> GetArtikelAsync()
        {
            var artikels = await this._auftragContext.Artikel.AsNoTracking().Include(x => x.Lieferant).ToListAsync();
            return artikels;
        }
    }
}
