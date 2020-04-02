using System.Collections.Generic;

using ImprovedDnbDataImporter.Models;

namespace ImprovedDnbDataImporter.Interfaces
{
    public interface IDnbDataParser
    {
        IReadOnlyCollection<InterestRateTermStructure> Parse(string data);
    }
}