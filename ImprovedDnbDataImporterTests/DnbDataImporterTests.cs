using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using ImprovedDnbDataImporter.Implementations;

using Moq;
using Moq.Protected;

using Shouldly;

using Xunit;

namespace ImprovedDnbDataImporterTests
{
    public class DnbDataImporterTests
    {
        [Fact]
        public async Task Import_WhenNonAcceptedStatusCodeOccurs_ThrowsHttpRequestException()
        {
            // Arrange
            var handlerMock = GetMockedHttpMessageHandler(HttpStatusCode.BadRequest, "");

            var httpClient = new HttpClient(handlerMock.Object);

            var sut = new DnbDataImporter(httpClient);

            // Act and Assert
            await Should.ThrowAsync<HttpRequestException>(async () => await sut.Import("").ConfigureAwait(false));
        }

        [Fact]
        public async Task Import_WhenAcceptedStatusCodeOccurs_ReturnsExpectedContent()
        {
            // Arrange
            var handlerMock = GetMockedHttpMessageHandler(HttpStatusCode.Accepted, "test!");

            var httpClient = new HttpClient(handlerMock.Object);

            var sut = new DnbDataImporter(httpClient);

            // Act
            var result = await sut.Import("myResourceId").ConfigureAwait(false);

            // Assert
            result.ShouldBe("test!");
        }

        [Fact]
        public async Task Dispose_RunningImportMethodAfterDisposing_ReturnsObjectDisposedException()
        {
            // Arrange
            var sut = new DnbDataImporter();
            sut.Dispose();

            // Act
            await Should
                .ThrowAsync<ObjectDisposedException>(async () => await sut.Import("myResourceId").ConfigureAwait(false))
                .ConfigureAwait(false);
        }

        private static Mock<HttpMessageHandler> GetMockedHttpMessageHandler(HttpStatusCode statusCode, string content)
        {
            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);

            handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = statusCode,
                    Content = new StringContent(content)
                })
                .Verifiable();

            return handlerMock;
        }
    }
}
