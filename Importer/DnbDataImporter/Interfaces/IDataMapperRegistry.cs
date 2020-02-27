﻿using DnbDataImporter.Mappers;
using DnbDataImporter.Models.Interfaces;

namespace DnbDataImporter.Interfaces
{
    public interface IDataMapperRegistry
    {
        void RegisterMapper<TDataRow, TDataMapper>()
            where TDataRow : IDataRow;

        DataMapperBase GetMapper<TDataRow>()
            where TDataRow : IDataRow;
    }
}