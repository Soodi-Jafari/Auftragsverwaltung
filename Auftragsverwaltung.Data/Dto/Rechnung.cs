using System;
using System.Collections.Generic;

#nullable disable

namespace Auftragsverwaltung.Data.Dto
{
    public partial class Rechnung
    {
        public Rechnung()
        {
            Auftrag = new HashSet<Auftrag>();
        }

        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public decimal Betrag { get; set; }
        public string Dateiname { get; set; }
        public string Url { get; set; }

        public virtual ICollection<Auftrag> Auftrag { get; set; }
    }
}
