using DnbDataImporter.Mappers;
using DnbDataImporter.Models.Interfaces;

namespace DnbDataImporter.Interfaces
{
    public interface IDataMapperRegistry
    {
        void RegisterMapper<TDataSequence, TDataMapper>()
            where TDataSequence : IDataSequence
            where TDataMapper : IDataMapper;

        IDataMapper GetMapper<TDataSequence>()
            where TDataSequence : IDataSequence;
    }
}