using System.IO;

using DnbDataImporter.Interfaces;
using DnbDataImporter.Mappers;
using DnbDataImporter.Models;

using Xunit;

namespace DnbDataImporter.Tests
{
    public class DataMapperRegistryTests
    {
        [Fact]
        public void RegisterMapper_()
        {

        }

        [Fact]
        public void TestCase()
        {
            var file = File.Open("YieldCurve.csv", FileMode.Open);
            var fileContents = new StreamReader(file).ReadToEnd();

            IDataMapperRegistry dataMapperRegistry = new DataMapperRegistry();
            dataMapperRegistry.RegisterMapper<YieldCurveDataRow, YieldCurveMapper>();

            var result = dataMapperRegistry.GetMapper<YieldCurveDataRow>();
            var foo = result.Map(fileContents);
        }
    }
}