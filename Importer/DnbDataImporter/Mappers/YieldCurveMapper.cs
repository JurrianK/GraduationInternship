using System;
using System.Collections.Generic;
using System.Globalization;

using DnbDataImporter.Models;
using DnbDataImporter.Models.Interfaces;

namespace DnbDataImporter.Mappers
{
    public class YieldCurveMapper : DataMapperBase
    {
        public override IEnumerable<IDataRow> Map(string csvData)
        {
            if (string.IsNullOrEmpty(csvData))
            {
                throw new ArgumentNullException(nameof(csvData));
            }

            var csvDataWithoutHeader = RemoveHeader(csvData);
            var yieldCurveDataRows = new List<YieldCurveDataRow>();

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

                yieldCurveDataRows.Add(
                    new YieldCurveDataRow
                        {
                            YearsToMaturity = Convert.ToInt32(data[0], CultureInfo.InvariantCulture),
                            Term = DateTime.Parse(data[1], CultureInfo.InvariantCulture),
                            Value = Convert.ToDouble(data[2], CultureInfo.InvariantCulture)
                        });
            }

            return yieldCurveDataRows;
        }
    }
}