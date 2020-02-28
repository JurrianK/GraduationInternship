using System;
using System.Collections.Generic;
using System.Globalization;

using DnbDataImporter.Models;
using DnbDataImporter.Models.Interfaces;

namespace DnbDataImporter.Mappers
{
    public class MarketInterestMapper : DataMapperBase
    {
        public override IEnumerable<IDataSequence> Map(string csvData)
        {
            if (string.IsNullOrEmpty(csvData))
            {
                throw new ArgumentNullException(nameof(csvData));
            }

            var csvDataWithoutHeader = RemoveHeader(csvData);
            var marketInterestDataSequences = new List<MarketInterestDataSequence>();

            foreach (var dataPoint in csvDataWithoutHeader)
            {
                if (string.IsNullOrEmpty(dataPoint))
                {
                    continue;
                }

                var data = dataPoint.Split(",");

                for (var index = 0; index < data.Length; index++)
                {
                    data[index] = data[index].Replace("\"", string.Empty);
                }

                marketInterestDataSequences.Add(
                    new MarketInterestDataSequence
                        {
                            MarketRate = data[0],
                            MarketRateKind = data[1],
                            Futures = data[2],
                            IndexKind = data[3],
                            Term = DateTime.Parse(data[4], CultureInfo.InvariantCulture),
                            Value = Convert.ToDouble(data[5], CultureInfo.InvariantCulture)
                        });
            }

            return marketInterestDataSequences;
        }
    }
}