using System;
using System.Collections.Generic;

#nullable disable

namespace Auftragsverwaltung.Data.Dto
{
    public partial class AuftragsPositionen
    {
        public int Id { get; set; }
        public int AuftragId { get; set; }
        public int Position { get; set; }
        public int ArtikelId { get; set; }
        public int Menge { get; set; }

        public virtual Artikel Artikel { get; set; }
        public virtual Auftrag Auftrag { get; set; }
    }
}
