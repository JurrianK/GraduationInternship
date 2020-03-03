using System;

using DnbDataImporter.Mappers;
using DnbDataImporter.Models;

using Shouldly;

using Xunit;

namespace DnbDataImporter.Tests
{
    public class DataMapperRegistryTests
    {
        [Fact]
        public void RegisterMapper_WhenSameDataSequenceIsAddedTwiceWithDifferentMappers_ThrowsArgumentException()
        {
            // Arrange
            var sut = new DataMapperRegistry();

            // Act
            sut.RegisterMapper<YieldCurveDataSequence, YieldCurveMapper>();

            // Assert
            Should.Throw<ArgumentException>(() => sut.RegisterMapper<YieldCurveDataSequence, MarketInterestMapper>());
        }

        [Fact]
        public void GetMapper_WhenNoDataSequenceHasBeenRegistered_ThrowsArgumentException()
        {
            // Arrange
            var sut = new DataMapperRegistry();

            // Act and assert
            Should.Throw<ArgumentException>(() => sut.GetMapper<YieldCurveDataSequence>());
        }

        [Fact]
        public void GetMapper_WhenRegisteringYieldCurveDataSequenceAndMapper_ReturnsExpectedMapper()
        {
            // Arrange
            var sut = new DataMapperRegistry();

            sut.RegisterMapper<YieldCurveDataSequence, YieldCurveMapper>();

            // Act
            var result = sut.GetMapper<YieldCurveDataSequence>();

            // Assert
            result.ShouldBeOfType<YieldCurveMapper>();
        }

        [Fact]
        public void GetMapper_WhenRegisteringMarketInterestDataSequenceAndMapper_ReturnsExpectedMapper()
        {
            // Arrange
            var sut = new DataMapperRegistry();

            sut.RegisterMapper<MarketInterestDataSequence, MarketInterestMapper>();

            // Act
            var result = sut.GetMapper<MarketInterestDataSequence>();

            // Assert
            result.ShouldBeOfType<MarketInterestMapper>();
        }

        [Fact]
        public void GetMapper_WhenRegisteringMultipleDataSequencesAndMappers_ReturnsDifferentMappersForDifferentSequences()
        {
            // Arrange
            var sut = new DataMapperRegistry();

            sut.RegisterMapper<YieldCurveDataSequence, YieldCurveMapper>();
            sut.RegisterMapper<MarketInterestDataSequence, MarketInterestMapper>();

            // Act
            var yieldCurveMapper = sut.GetMapper<YieldCurveDataSequence>();
            var marketInterestMapper = sut.GetMapper<MarketInterestDataSequence>();

            // Assert
            yieldCurveMapper.ShouldBeOfType<YieldCurveMapper>();
            marketInterestMapper.ShouldBeOfType<MarketInterestMapper>();
        }
    }
}