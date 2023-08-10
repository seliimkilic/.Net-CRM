using System;
using System.Collections.Generic;

#nullable disable

namespace CRM.Model
{
    public partial class Izinler
    {
        public int Id { get; set; }
        public int? KonuId { get; set; }
        public int? RolId { get; set; }
        public int? KullanıcıId { get; set; }
        public bool? Durum { get; set; }
    }
}
