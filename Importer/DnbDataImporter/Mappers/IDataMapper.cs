using System.Collections.Generic;

using DnbDataImporter.Models.Interfaces;

namespace DnbDataImporter.Mappers
{
    public interface IDataMapper
    {
        IEnumerable<IDataRow> Map(string csvData);
    }
}