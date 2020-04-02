using System.Threading.Tasks;

using ImprovedDnbDataImporter.Implementations;

namespace ImprovedDnbDataImporter
{
    internal static class Program
    {
        internal static async Task Main()
        {
            var dataImporter = new DnbDataImporter();
            var importedResult = await dataImporter.Import("60304cad-97ba-4974-a0ed-05597c91e37c").ConfigureAwait(false);
            dataImporter.Dispose();
            
            var dnbDataParser = new DnbDataParser();
            var parsedData = dnbDataParser.Parse(importedResult);
        }
    }
}
