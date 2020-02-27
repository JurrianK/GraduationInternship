using System.Threading.Tasks;

namespace DnbDataImporter.Interfaces
{
    public interface IDnbDataSetImporter
    {
        Task<string> LoadDataSet(string resourceId);
    }
}