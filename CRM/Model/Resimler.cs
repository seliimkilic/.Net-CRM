using System;
using System.Collections.Generic;

#nullable disable

namespace CRM.Model
{
    public partial class Resimler
    {
        public int StImageId { get; set; }
        public int KonuId { get; set; }
        public double? StId { get; set; }
        public string Tipi { get; set; }
        public string ImageName { get; set; }
        public string ImageUrl { get; set; }
        public int? CevapId { get; set; }
    }
}
