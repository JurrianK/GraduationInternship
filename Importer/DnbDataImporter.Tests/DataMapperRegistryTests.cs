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
        public void RegisterMapper_WhenSameDataRowIsAddedTwiceWithDifferentMappers_ReturnsFirstRegisteredMapper()
        {
            // Arrange
            var sut = new DataMapperRegistry();

            // Act
            sut.RegisterMapper<YieldCurveDataRow, YieldCurveMapper>();
            sut.RegisterMapper<YieldCurveDataRow, MarketInterestMapper>();

            var result = sut.GetMapper<YieldCurveDataRow>();

            // Assert
            result.ShouldBeOfType<YieldCurveMapper>();
        }

        [Fact]
        public void GetMapper_WhenNoDataRowHasBeenRegistered_ThrowsArgumentNullException()
        {
            // Arrange
            var sut = new DataMapperRegistry();

            // Act and assert
            Should.Throw<ArgumentNullException>(() => sut.GetMapper<YieldCurveDataRow>());
        }

        [Fact]
        public void GetMapper_WhenRegisteringYieldCurveDataRowAndMapper_ReturnsExpectedMapper()
        {
            // Arrange
            var sut = new DataMapperRegistry();

            sut.RegisterMapper<YieldCurveDataRow, YieldCurveMapper>();

            // Act
            var result = sut.GetMapper<YieldCurveDataRow>();

            // Assert
            result.ShouldBeOfType<YieldCurveMapper>();
        }

        [Fact]
        public void GetMapper_WhenRegisteringMarketInterestDataRowAndMapper_ReturnsExpectedMapper()
        {
            // Arrange
            var sut = new DataMapperRegistry();

            sut.RegisterMapper<MarketInterestDataRow, MarketInterestMapper>();

            // Act
            var result = sut.GetMapper<MarketInterestDataRow>();

            // Assert
            result.ShouldBeOfType<MarketInterestMapper>();
        }

        [Fact]
        public void GetMapper_WhenRegisteringMultipleDataRowsAndMappers_ReturnsDifferentMappersForDifferentRows()
        {
            // Arrange
            var sut = new DataMapperRegistry();

            sut.RegisterMapper<YieldCurveDataRow, YieldCurveMapper>();
            sut.RegisterMapper<MarketInterestDataRow, MarketInterestMapper>();

            // Act
            var yieldCurveMapper = sut.GetMapper<YieldCurveDataRow>();
            var marketInterestMapper = sut.GetMapper<MarketInterestDataRow>();

            // Assert
            yieldCurveMapper.ShouldBeOfType<YieldCurveMapper>();
            marketInterestMapper.ShouldBeOfType<MarketInterestMapper>();
        }
    }
}