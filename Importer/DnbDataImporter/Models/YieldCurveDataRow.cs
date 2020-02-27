using System;

using DnbDataImporter.Models.Interfaces;

namespace DnbDataImporter.Models
{
    public class YieldCurveDataRow : IDataRow
    {
        public int YearsToMaturity { get; set; }

        public DateTime Term { get; set; }

        public double Value { get; set; }
    }
}