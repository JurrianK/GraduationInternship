using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using ImprovedDnbDataImporter.Interfaces;
using ImprovedDnbDataImporter.Models;

namespace ImprovedDnbDataImporter.Implementations
{
    public class DnbDataParser : IDnbDataParser
    {
        public IReadOnlyCollection<InterestRateTermStructure> Parse(string data)
        {
            var separatedContents = SplitInParts("\n", data);

            var separatedContentsWithoutHeader = RemoveHeader(separatedContents);

            return Parse(separatedContentsWithoutHeader);
        }

        private static IReadOnlyCollection<InterestRateTermStructure> Parse(IEnumerable<string> contentsWithoutHeader)
        {
            var interestRateTermStructures = new List<InterestRateTermStructure>();

            foreach (var row in contentsWithoutHeader)
            {
                var rowSplit = SplitInParts(",", row);

                if (rowSplit.Length < 3)
                {
                    continue;
                }

                var maturityInYears = int.Parse(rowSplit[0], CultureInfo.InvariantCulture);
                var term = DateTime.Parse(rowSplit[1], CultureInfo.InvariantCulture);
                var value = decimal.Parse(rowSplit[2], CultureInfo.InvariantCulture);

                interestRateTermStructures.Add(new InterestRateTermStructure(maturityInYears, term, value));
            }

            return interestRateTermStructures;
        }

        private static IEnumerable<string> RemoveHeader(IEnumerable<string> data)
        {
            return data.Skip(1).ToArray();
        }

        private static string[] SplitInParts(string separator, string data)
        {
            return data.Split(separator);
        }
    }
}