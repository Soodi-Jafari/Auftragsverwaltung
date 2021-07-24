using System;
using System.Collections.Generic;

#nullable disable

namespace Auftragsverwaltung.Data.Dto
{
    public partial class Auftrag
    {
        public Auftrag()
        {
            AuftragsPositionen = new HashSet<AuftragsPositionen>();
        }

        public int Id { get; set; }
        public int KundeId { get; set; }
        public int? RechnungId { get; set; }
        public DateTime Datum { get; set; }
        public decimal Betrag { get; set; }
        public bool IstBezahlt { get; set; }

        public virtual Kunde Kunde { get; set; }
        public virtual Rechnung Rechnung { get; set; }
        public virtual ICollection<AuftragsPositionen> AuftragsPositionen { get; set; }
    }
}
