using System;

using DnbDataImporter.Models.Interfaces;

namespace DnbDataImporter.Models
{
    public class YieldCurveDataSequence : IDataSequence
    {
        public int YearsToMaturity { get; set; }

        public DateTime Term { get; set; }

        public double Value { get; set; }
    }
}