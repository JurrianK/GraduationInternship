using System;
using System.Collections.Generic;

using DnbDataImporter.Interfaces;
using DnbDataImporter.Mappers;
using DnbDataImporter.Models.Interfaces;

namespace DnbDataImporter
{
    public class DataMapperRegistry : IDataMapperRegistry
    {
        private readonly IDictionary<Type, Type> mappingDictionary;

        public DataMapperRegistry()
        {
            this.mappingDictionary = new Dictionary<Type, Type>();
        }

        public void RegisterMapper<TDataRow, TDataMapper>()
            where TDataRow : IDataRow
            where TDataMapper : IDataMapper
        {
            this.mappingDictionary.TryAdd(typeof(TDataRow), typeof(TDataMapper));
        }

        public IDataMapper GetMapper<TDataRow>()
            where TDataRow : IDataRow
        {
            this.mappingDictionary.TryGetValue(typeof(TDataRow), out var result);

            if (result == null)
            {
                throw new ArgumentNullException($"{typeof(TDataRow).Name} has not been registered yet.");
            }

            return (IDataMapper)Activator.CreateInstance(result);
        }
    }
}