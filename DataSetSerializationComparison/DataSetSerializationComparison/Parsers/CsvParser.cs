using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace DataSetSerializationComparison.Parsers
{
    public class CsvParser : IParser
    {
        public IEnumerable<YieldCurveModel> Parse(string resourceName)
        {
            using (var streamReader = new StreamReader(resourceName))
            {
                var yieldCurveContents = new List<YieldCurveModel>();

                if (streamReader.EndOfStream)
                {
                    return yieldCurveContents;
                }

                var csvContent = streamReader.ReadToEnd();

                var csvContentWithoutHeader = RemoveHeaderFromCsvFile(csvContent);

                foreach (var csvLine in csvContentWithoutHeader)
                {
                    if (string.IsNullOrEmpty(csvLine))
                    {
                        continue;
                    }

                    try
                    {
                        var lineContents = csvLine.Split(",");

                        yieldCurveContents.Add(
                            new YieldCurveModel
                                {
                                    YearsToMaturity = Convert.ToInt32(lineContents[0], CultureInfo.InvariantCulture),
                                    Term = DateTime.Parse(lineContents[1], CultureInfo.InvariantCulture),
                                    Value = Convert.ToDouble(lineContents[2], CultureInfo.InvariantCulture)
                                });
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }

                return yieldCurveContents;
            }
        }

        private static IEnumerable<string> RemoveHeaderFromCsvFile(string csvContent)
        {
            return csvContent.Split("\n").Skip(1);
        }
    }
}