using System;

namespace ImprovedDnbDataImporter.Models
{
    public readonly struct InterestRateTermStructure
    {
        public InterestRateTermStructure(int maturityInYears, DateTime term, decimal value)
        {
            this.MaturityInYears = maturityInYears;
            this.Term = term;
            this.Value = value;
        }

        public int MaturityInYears { get; }

        public DateTime Term { get; }

        public decimal Value { get; }
    }
}