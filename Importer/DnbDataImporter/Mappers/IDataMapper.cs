using System.Collections.Generic;

using DnbDataImporter.Models.Interfaces;

namespace DnbDataImporter.Mappers
{
    public interface IDataMapper
    {
        IEnumerable<IDataSequence> Map(string csvData);
    }
}