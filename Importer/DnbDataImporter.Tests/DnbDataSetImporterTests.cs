using System.Threading.Tasks;

using Xunit;

namespace DnbDataImporter.Tests
{
    public class DnbDataSetImporterTests
    {
        [Fact]
        public async Task Foo()
        {
            const string ResourceId = "60304cad-97ba-4974-a0ed-05597c91e37c";

            using (var dnbDataSetImporter = new DnbDataSetImporter())
            {
                var result = await dnbDataSetImporter
                                 .LoadDataSet(ResourceId)
                                 .ConfigureAwait(false);
            }
        }
    }
}