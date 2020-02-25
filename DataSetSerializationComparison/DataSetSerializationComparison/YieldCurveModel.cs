using System;

namespace DataSetSerializationComparison
{
    public class YieldCurveModel
    {
        public int YearsToMaturity { get; set; }

        public DateTime Term { get; set; }

        public double Value { get; set; }
    }
}