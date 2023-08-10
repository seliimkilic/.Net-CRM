using System;
using System.Collections.Generic;

#nullable disable

namespace CRM.Model
{
    public partial class KonuTuru
    {
        public KonuTuru()
        {
            Konulars = new HashSet<Konular>();
        }

        public int Id { get; set; }
        public string Ad { get; set; }
        public bool? Aktif { get; set; }

        public virtual ICollection<Konular> Konulars { get; set; }
    }
}
