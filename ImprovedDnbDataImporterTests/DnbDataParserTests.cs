using System;

using ImprovedDnbDataImporter.Implementations;

using Shouldly;

using Xunit;

namespace ImprovedDnbDataImporterTests
{
    public class DnbDataParserTests
    {
        [Fact]
        public void Parse_DataStringIsNull_ThrowsNullReferenceException()
        {
            // Arrange
            var sut = new DnbDataParser();

            // Act and assert
            Should.Throw<NullReferenceException>(() => sut.Parse(null));
        }

        [Fact]
        public void Parse_WhenContentIsNotCorrectFormat_ThrowsFormatException()
        {
            // Arrange
            const string CsvContents = @"header1,header2,header3
                                         data1,data2,data3";

            var sut = new DnbDataParser();

            // Act and Assert
            Should.Throw<FormatException>(() => sut.Parse(CsvContents));
        }

        [Fact]
        public void Parse_WhenOnlyHeaderIsPresent_ReturnsEmptyList()
        {
            // Arrange
            const string CsvContents = "header1,header2,header3";

            var sut = new DnbDataParser();

            // Act
            var result = sut.Parse(CsvContents);

            // Assert
            result.Count.ShouldBe(0);
        }

        [Fact]
        public void Parse_ValidCsvContents_ListContainsTwoItems()
        {
            const string CsvContents = @"header1,header2,header3
                                         1,2020-01-01,0.123
                                         2,2020-02-02,0.456";

            var sut = new DnbDataParser();

            // Act
            var result = sut.Parse(CsvContents);

            // Assert
            result.Count.ShouldBe(2);
        }
    }
}