using Auftragsverwaltung.Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auftragsverwaltung.Web.Services
{
    public interface IAuftragService
    {
        Task<Auftrag> GetAuftragAsync(int id);
        Task<Auftrag> UpdateAuftragAsync(Auftrag auftrag);
        Task<Auftrag> CreateAuftragAsync(Auftrag auftrag);
        Task<IEnumerable<Auftrag>> GetAuftragOverviewAsync(DateTime? from, DateTime? till);
    }
}
