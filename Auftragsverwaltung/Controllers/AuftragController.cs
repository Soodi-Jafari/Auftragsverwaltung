using Auftragsverwaltung.Data;
using Auftragsverwaltung.Data.Dto;
using Auftragsverwaltung.Models;
using Auftragsverwaltung.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Auftragsverwaltung.Controllers
{
    public class AuftragController : Controller
    {
        private readonly ILogger<AuftragController> _logger;
        private readonly IAuftragService _auftragService;
        private readonly IArtikelService _artikelService;

        public AuftragController(ILogger<AuftragController> logger, IAuftragService auftragService, IArtikelService artikelService)
        {
            _logger = logger;
            _auftragService = auftragService;
            _artikelService = artikelService;
        }

        public async Task<IActionResult> Index(DateTime? von, DateTime? bis)
        {
            var list = await _auftragService.GetAuftragOverviewAsync(von, bis);
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var auftrag = await _auftragService.GetAuftragAsync(id);
            var artikel = await _artikelService.GetArtikelAsync();
            ViewData["Artikel"] = new SelectList(artikel, nameof(Artikel.Id), nameof(Artikel.Bezeichnung));
            if (auftrag == null)
            {
                _logger.LogWarning($"Auftrag mit Id {0} nicht gefunden", id);
                return NotFound();
            }
            return View(auftrag);
        }

        [HttpGet]
        public async Task<IActionResult> CreateAuftrag()
        {
            var auftrag = new Auftrag()
            {
                Betrag = 0,
                KundeId = 1,
                Datum = DateTime.Now,
                IstBezahlt = false
            };
            var a = await this._auftragService.CreateAuftragAsync(auftrag);
            return View(auftrag);
        }


        [HttpPost]
        public async Task<IActionResult> CreateAuftrag(Auftrag auftrag)
        {
            auftrag = await _auftragService.CreateAuftragAsync(auftrag);
            if (auftrag == null)
                _logger.LogError("Fehler beim Registrieren des Auftrag");
            return View(auftrag);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAuftrag(Auftrag auftrag)
        {
            auftrag = await _auftragService.UpdateAuftragAsync(auftrag);
            if (auftrag == null)
                _logger.LogError("Fehler beim Bearbeiten des Auftrag");
            return View(auftrag);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
