using System.Net.Http.Json;
using System.Net;
using Moq.Protected;
using Moq;
using NWLED;
using NWled.Requests;
using NWled.Models;

namespace NWled.Tests;

public class WLedClientTests
{
    private const string BaseUri = "http://localhost/";

    [Fact]
    public async Task GetAsync_ReturnsWLedRoot_WhenResponseIsSuccessful()
    {
        // Arrange
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = JsonContent.Create(new WLedRoot()),
            });

        var client = new WLedClient(mockHandler.Object, BaseUri);

        // Act
        var result = await client.GetAsync();

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetStateAsync_ReturnsState_WhenResponseIsSuccessful()
    {
        // Arrange
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = JsonContent.Create(new State()),
            });

        var client = new WLedClient(mockHandler.Object, BaseUri);

        // Act
        var result = await client.GetStateAsync();

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetInformationAsync_ReturnsInformation_WhenResponseIsSuccessful()
    {
        // Arrange
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = JsonContent.Create(new Information()),
            });

        var client = new WLedClient(mockHandler.Object, BaseUri);

        // Act
        var result = await client.GetInformationAsync();

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetEffectsAsync_ReturnsEffects_WhenResponseIsSuccessful()
    {
        // Arrange
        var mockHandler = new Mock<HttpMessageHandler>();
        var effects = new[] { "effect1", "effect2" };
        mockHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = JsonContent.Create(effects),
            });

        var client = new WLedClient(mockHandler.Object, BaseUri);

        // Act
        var result = await client.GetEffectsAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public async Task PostAsync_CallsPostAsJson_WhenRequestIsSuccessful()
    {
        // Arrange
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
            });

        var client = new WLedClient(mockHandler.Object, BaseUri);
        var request = new WLedRootRequest();

        // Act
        await client.PostAsync(request);

        // Assert
        mockHandler.Protected().Verify(
            "SendAsync",
            Times.Once(),
            ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Post && req.RequestUri == new Uri(BaseUri + "json")),
            ItExpr.IsAny<CancellationToken>());
    }

}
