using System;
using System.Collections.Generic;

namespace PinKripto05.Models
{
    public partial class KriptoTrades
    {
        public long KriptoId { get; set; }
        public int? KriptoRank { get; set; }
        public string Symbol { get; set; }
        public string KriptoName { get; set; }
        public decimal? Usd { get; set; }
        public DateTime? DatumUnosa { get; set; }
        public float? Change1h { get; set; }
        public float? Change24h { get; set; }
        public float? Change7d { get; set; }
    }
}
