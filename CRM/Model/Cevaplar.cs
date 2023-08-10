using System;
using System.Collections.Generic;

#nullable disable

namespace CRM.Model
{
    public partial class Cevaplar
    {
        public int Id { get; set; }
        public int? KonuId { get; set; }
        public int? GorusenId { get; set; }
        public string Gorusulen { get; set; }
        public string Cevap { get; set; }
        public double? CariId { get; set; }
        public DateTime? Tarih { get; set; }

        public virtual Kullanıcılar Gorusen { get; set; }
        public virtual Konular Konu { get; set; }
    }
}
