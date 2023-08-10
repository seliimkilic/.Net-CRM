using System;
using System.Collections.Generic;

#nullable disable

namespace CRM.Model
{
    public partial class Konular
    {
        public Konular()
        {
            Cevaplars = new HashSet<Cevaplar>();
        }

        public int KonuId { get; set; }
        public string Konu { get; set; }
        public DateTime? Tarih { get; set; }
        public bool? AktifPasif { get; set; }
        public int? TurId { get; set; }
        public double? StokId { get; set; }
        public double? CariId { get; set; }
        public int? KullanıcıId { get; set; }

        public virtual KonuTuru Tur { get; set; }
        public virtual ICollection<Cevaplar> Cevaplars { get; set; }
    }
}
