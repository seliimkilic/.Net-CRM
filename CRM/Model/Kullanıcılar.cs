using System;
using System.Collections.Generic;

#nullable disable

namespace CRM.Model
{
    public partial class Kullanıcılar
    {
        public Kullanıcılar()
        {
            Cevaplars = new HashSet<Cevaplar>();
        }

        public int Id { get; set; }
        public int? RolId { get; set; }
        public string AdSoyad { get; set; }

        public virtual ICollection<Cevaplar> Cevaplars { get; set; }
    }
}
