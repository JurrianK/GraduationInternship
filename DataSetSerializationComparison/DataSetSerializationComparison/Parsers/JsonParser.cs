using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DataSetSerializationComparison.Parsers
{
    public class JsonParser : IParser
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

                var jsonContent = streamReader.ReadToEnd();

                var foo = JsonSerializer.Deserialize<YieldCurveContainerClass>(jsonContent);

                foreach (var item in foo.YieldCurveData)
                {
                    try
                    {
                        var yearsToMaturityJsonElement = (JsonElement)item.GetValue(0);
                        var termJsonElement = (JsonElement)item.GetValue(1);
                        var valueJsonElement = (JsonElement)item.GetValue(2);

                        var yearsToMaturity = yearsToMaturityJsonElement.GetInt32();
                        var value = valueJsonElement.GetDouble();

                        yieldCurveContents.Add(
                            new YieldCurveModel
                                {
                                    YearsToMaturity = yearsToMaturity,
                                    Term = DateTime.Parse("2019-08-01T00:00:00-07:00"),
                                    Value = value
                                });
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }

                return yieldCurveContents;
            }
        }

        private class YieldCurveContainerClass
        {
            [JsonPropertyName("name")]
            public string Name { get; set; }

            [JsonPropertyName("labels")]
            public string[] Labels { get; set; }

            [JsonPropertyName("data")]
            public object[][] YieldCurveData { get; set; }
        }
    }
}