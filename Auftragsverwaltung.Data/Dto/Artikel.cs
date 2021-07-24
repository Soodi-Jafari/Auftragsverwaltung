using System;
using System.Collections.Generic;

#nullable disable

namespace Auftragsverwaltung.Data.Dto
{
    public partial class Artikel
    {
        public Artikel()
        {
            AuftragsPositionen = new HashSet<AuftragsPositionen>();
        }

        public int Id { get; set; }
        public string Bezeichnung { get; set; }
        public int LieferantId { get; set; }
        public decimal? PreisNetto { get; set; }
        public int MwstSatz { get; set; }

        public virtual Lieferant Lieferant { get; set; }
        public virtual ICollection<AuftragsPositionen> AuftragsPositionen { get; set; }
    }
}
