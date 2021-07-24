using System;
using System.Collections.Generic;

#nullable disable

namespace Auftragsverwaltung.Data.Dto
{
    public partial class Lieferant
    {
        public Lieferant()
        {
            Artikel = new HashSet<Artikel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Strasse { get; set; }
        public string Plz { get; set; }
        public string Ort { get; set; }
        public string Telefon { get; set; }

        public virtual ICollection<Artikel> Artikel { get; set; }
    }
}
