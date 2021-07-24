using System;
using System.Collections.Generic;

#nullable disable

namespace Auftragsverwaltung.Data.Dto
{
    public partial class Kunde
    {
        public Kunde()
        {
            Auftrag = new HashSet<Auftrag>();
        }

        public int Id { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Strasse { get; set; }
        public string Plz { get; set; }
        public string Ort { get; set; }
        public string Telefon { get; set; }

        public virtual ICollection<Auftrag> Auftrag { get; set; }
    }
}
