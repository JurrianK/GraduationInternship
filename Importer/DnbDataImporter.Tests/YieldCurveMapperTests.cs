﻿using System;
using System.IO;
using System.Linq;

using DnbDataImporter.Mappers;

using Shouldly;

using Xunit;

namespace DnbDataImporter.Tests
{
    public class YieldCurveMapperTests
    {
        private const string CsvFile = "YieldCurve.csv";

        private readonly string csvContents;

        public YieldCurveMapperTests()
        {
            var csvFile = File.Open(CsvFile, FileMode.Open);

            using (var streamReader = new StreamReader(csvFile))
            {
                this.csvContents = streamReader.ReadToEnd();
            }
        }

        [Fact]
        public void Map_WhenCsvDataIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            var sut = new YieldCurveMapper();

            // Act and assert
            Should.Throw<ArgumentNullException>(() => sut.Map(null));
        }

        [Fact]
        public void Map_WhenNothingIsLeftAfterRemovingHeaders_ReturnsEmptyList()
        {
            // Arrange
            var sut = new YieldCurveMapper();

            // Act
            var result = sut.Map("test\n");

            // Assert
            result.Count().ShouldBe(0);
        }

        [Fact]
        public void Map_WhenParsingCsvFile_ReturnsExpectedAmountOfModels()
        {
            // Arrange
            const int ExpectedAmountOfModels = 100;

            var sut = new YieldCurveMapper();

            // Act
            var result = sut.Map(this.csvContents);

            // Assert
            result.Count().ShouldBe(ExpectedAmountOfModels);
        }
    }
}