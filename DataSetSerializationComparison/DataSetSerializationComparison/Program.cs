using System;
using System.Diagnostics;

using DataSetSerializationComparison.Parsers;

namespace DataSetSerializationComparison
{
    public static class Program
    {
        public static void Main()
        {
            var stopWatch = new Stopwatch();

            // CSV parsing speed
            stopWatch.Start();

            var csvParser = new CsvParser();
            var csvParserResults = csvParser.Parse("YieldCurve.csv");

            stopWatch.Stop();
            var elapsed = stopWatch.Elapsed;

            Console.WriteLine($"CSV parsing took {elapsed.Minutes}:{elapsed.Seconds}:{elapsed.Milliseconds}");

            stopWatch.Reset();

            // JSON parsing speed
            stopWatch.Start();

            var jsonParser = new JsonParser();
            var jsonParserResults = jsonParser.Parse("YieldCurve.json");

            stopWatch.Stop();

            elapsed = stopWatch.Elapsed;

            Console.WriteLine($"JSON parsing took {elapsed.Minutes}:{elapsed.Seconds}:{elapsed.Milliseconds}");

            stopWatch.Reset();
            
            // XLSX parsing speed
            stopWatch.Start();
            
            var excelParser = new ExcelParser();
            var excelParserResults = excelParser.Parse("YieldCurve.xlsx");

            stopWatch.Stop();

            elapsed = stopWatch.Elapsed;

            Console.WriteLine($"XLSX parsing took {elapsed.Minutes}:{elapsed.Seconds}:{elapsed.Milliseconds}");
        }
    }
}
