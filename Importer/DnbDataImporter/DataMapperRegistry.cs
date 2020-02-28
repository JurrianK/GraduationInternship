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

        public void RegisterMapper<TDataSequence, TDataMapper>()
            where TDataSequence : IDataSequence
            where TDataMapper : IDataMapper
        {
            var successfulRegistration = this.mappingDictionary.TryAdd(typeof(TDataSequence), typeof(TDataMapper));

            if (!successfulRegistration)
            {
                throw new ArgumentException($"{typeof(TDataSequence)} has already been registered.");
            }
        }

        public IDataMapper GetMapper<TDataSequence>()
            where TDataSequence : IDataSequence
        {
            this.mappingDictionary.TryGetValue(typeof(TDataSequence), out var result);

            if (result == null)
            {
                throw new ArgumentException($"{typeof(TDataSequence)} has not been registered yet.");
            }

            return (IDataMapper)Activator.CreateInstance(result);
        }
    }
}