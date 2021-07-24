using Auftragsverwaltung.Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auftragsverwaltung.Web.Services
{
    public interface IArtikelService
    {
        Task<IEnumerable<Artikel>> GetArtikelAsync();
    }
}
