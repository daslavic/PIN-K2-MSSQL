﻿using System;
using System.Collections.Generic;

namespace PinKripto05.Models
{
    public partial class Prod
    {
        public long ProductId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Color { get; set; }
        public decimal UnitPrice { get; set; }
        public long AvailableQuantity { get; set; }
        public DateTime CratedDate { get; set; }
    }
}
