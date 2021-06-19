using System;
using System.Collections.Generic;

#nullable disable

namespace Medicine_tracking.Models
{
    public partial class MediDb
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int ExpiryDate { get; set; }
        public string Notes { get; set; }
    }
}
