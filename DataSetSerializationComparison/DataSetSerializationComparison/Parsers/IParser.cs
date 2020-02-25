using System.Collections.Generic;

namespace DataSetSerializationComparison.Parsers
{
    public interface IParser
    {
        IEnumerable<YieldCurveModel> Parse(string resourceName);
    }
}