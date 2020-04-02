using System.Threading.Tasks;

namespace ImprovedDnbDataImporter.Interfaces
{
    public interface IDnbDataImporter
    {
        Task<string> Import(string csvResourceId);
    }
}