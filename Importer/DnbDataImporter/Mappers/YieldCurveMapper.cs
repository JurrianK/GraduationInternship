using System;
using System.Collections.Generic;
using System.Globalization;

using DnbDataImporter.Models;
using DnbDataImporter.Models.Interfaces;

namespace DnbDataImporter.Mappers
{
    public class YieldCurveMapper : DataMapperBase
    {
        public override IEnumerable<IDataSequence> Map(string csvData)
        {
            if (string.IsNullOrEmpty(csvData))
            {
                throw new ArgumentNullException(nameof(csvData));
            }

            var csvDataWithoutHeader = RemoveHeader(csvData);
            var yieldCurveDataSequences = new List<YieldCurveDataSequence>();

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

                yieldCurveDataSequences.Add(
                    new YieldCurveDataSequence
                        {
                            YearsToMaturity = Convert.ToInt32(data[0], CultureInfo.InvariantCulture),
                            Term = DateTime.Parse(data[1], CultureInfo.InvariantCulture),
                            Value = Convert.ToDouble(data[2], CultureInfo.InvariantCulture)
                        });
            }

            return yieldCurveDataSequences;
        }
    }
}