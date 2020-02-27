using System.Collections.Generic;
using System.Linq;

using DnbDataImporter.Models.Interfaces;

namespace DnbDataImporter.Mappers
{
    public abstract class DataMapperBase : IDataMapper
    {
        public abstract IEnumerable<IDataRow> Map(string csvData);

        protected static IEnumerable<string> RemoveHeader(string csvData)
        {
            return csvData.Split("\n").Skip(1);
        }
    }
}