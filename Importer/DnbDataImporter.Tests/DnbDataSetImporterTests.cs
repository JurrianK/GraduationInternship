using System;

using NSubstitute;

using Shouldly;

using Xunit;

namespace DnbDataImporter.Tests
{
    public class DnbDataSetImporterTests
    {
        private const string ResourceUrl = "DnbWebsiteUrl";

        [Fact]
        public void LoadDataSet_WhenNullInputIsGivenToConstructor_ThrowsArgumentException()
        {
            // Arrange
            var sut = new DnbDataSetImporter(null);

            // Act and assert
            Should.Throw<ArgumentException>(() => sut.LoadDataSet(Arg.Any<string>()));
        }

        [Fact]
        public void LoadDataSet_WhenNullInputIsGivenAsResourceId_ThrowsArgumentNullException()
        {
            // Arrange
            var sut = new DnbDataSetImporter(ResourceUrl);

            // Act and assert
            Should.Throw<ArgumentNullException>(() => sut.LoadDataSet(null));
        }
    }
}