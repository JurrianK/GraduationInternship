using System;

using DnbDataImporter.Models.Interfaces;

namespace DnbDataImporter.Models
{
    public class MarketInterestDataSequence : IDataSequence
    {
        public string MarketRate { get; set; }

        public string MarketRateKind { get; set; }

        public string Futures { get; set; }

        public string IndexKind { get; set; }

        public DateTime Term { get; set; }

        public double Value { get; set; }
    }
}