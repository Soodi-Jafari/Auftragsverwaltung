using Auftragsverwaltung.Data;
using Auftragsverwaltung.Web.Services;
using System;
using Xunit;
using Microsoft.Extensions.Logging;
using Auftragsverwaltung.Data.Dto;
using System.Collections.Generic;

namespace Auftragverwaltung.Test
{
    public class AuftragServiceTest
    {
        AuftragDbContext _dbContext = new AuftragDbContext();
        public AuftragServiceTest()
        {
            _dbContext = new AuftragDbContext();
        }

        [Fact]
        public async void CreateAuftragAsync_ReturnIsAuftrag()
        {
            AuftragService service = new AuftragService(_dbContext);
            Auftrag auftrag = new Auftrag()
            {
                KundeId = 2,
                Datum = DateTime.Now,
                IstBezahlt = false,
                AuftragsPositionen = new List<AuftragsPositionen> {
                    new AuftragsPositionen {ArtikelId = 3, Menge = 3, Position = 1 }
                }
            };

            var result = await service.CreateAuftragAsync(auftrag);
            Assert.IsType<Auftrag>(result);

        }

        [Fact]
        public async void UpdateAuftragAsync_ReturnIsAuftrag()
        {
            _dbContext = new AuftragDbContext();
            AuftragService service = new AuftragService(_dbContext);
            Auftrag auftrag = new Auftrag()
            {
                Id = 1,
                KundeId = 2,
                Datum = DateTime.Now,
                IstBezahlt = false,
                AuftragsPositionen = new List<AuftragsPositionen> {
                    new AuftragsPositionen {Id = 1, ArtikelId = 5, Menge = 3, Position = 1 },
                    new AuftragsPositionen {Id = 2, ArtikelId = 3, Menge = 4, Position = 2 }, // edit position
                   // new AuftragsPositionen {Id = 3, ArtikelId = 2, Menge = 2, Position = 3 } // delete position
                    new AuftragsPositionen {AuftragId = 1, ArtikelId = 6, Menge = 1, Position = 4 } // add position
                }
            };

            var result = await service.UpdateAuftragAsync(auftrag);

            Assert.IsType<Auftrag>(result);

        }

        [Fact]
        public async void GetAuftragAsync_ReturnIsAuftrag()
        {
            AuftragService service = new AuftragService(_dbContext);
            int id = 1;

            var result = await service.GetAuftragAsync(id);

            Assert.IsType<Auftrag>(result);

        }

        [Fact]
        public async void GetAuftragOverviewAsync_GetAll_ReturnIsAuftrag()
        {
            AuftragService service = new AuftragService(_dbContext);

            var result = await service.GetAuftragOverviewAsync();

            Assert.IsType<List<Auftrag>>(result);

        }

        [Fact]
        public async void GetAuftragOverviewAsync_FilterDate_ReturnMatchResult()
        {
            AuftragService service = new AuftragService(_dbContext);

            var date = new DateTime(2021, 7, 3);
            var result = await service.GetAuftragOverviewAsync(date, date);

            foreach (var item in result)
                Assert.Equal(item.Datum, date);

        }
    }
}
