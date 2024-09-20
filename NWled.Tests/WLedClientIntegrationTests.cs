using NWLED;
using NWled.Requests;
using NWled.Models;

namespace NWled.Tests;

public class WLedClientIntegrationTests
{
    private const string BaseUri = "http://wled-279a34.local/"; // Replace with your WLED instance IP

    [Fact]
    public async Task GetAsync_ReturnsWLedRoot()
    {
        // Arrange
        var client = new WLedClient(BaseUri);

        // Act
        var result = await client.GetAsync();

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.State); 
    }

    [Fact]
    public async Task GetStateAsync_ReturnsState()
    {
        // Arrange
        var client = new WLedClient(BaseUri);

        // Act
        var result = await client.GetStateAsync();

        // Assert
        Assert.NotNull(result);
        Assert.IsType<State>(result);
    }

    [Fact]
    public async Task GetInformationAsync_ReturnsInformation()
    {
        // Arrange
        var client = new WLedClient(BaseUri);

        // Act
        var result = await client.GetInformationAsync();

        // Assert
        Assert.NotNull(result);
        Assert.False(string.IsNullOrEmpty(result.VersionName)); 
    }

    [Fact]
    public async Task GetEffectsAsync_ReturnsEffects()
    {
        // Arrange
        var client = new WLedClient(BaseUri);

        // Act
        var result = await client.GetEffectsAsync();

        // Assert
        Assert.NotNull(result);
        Assert.NotEmpty(result);
    }

    [Fact]
    public async Task PostAsync_SendsRequestFalseSuccessfully()
    {
        // Arrange
        var client = new WLedClient(BaseUri);
        var state = new State
        {
            On = false
        };

        // Act
        await client.PostAsync(state);

        var stateResponse = await client.GetStateAsync();
        Assert.False(stateResponse.On);
    }
    [Fact]
    public async Task PostAsync_SendsRequestTrueSuccessfully()
    {
        // Arrange
        var client = new WLedClient(BaseUri);
        var state = new State
        {
            On = true
        };

        // Act
        await client.PostAsync(state);

        var stateResponse = await client.GetStateAsync();
        Assert.True(stateResponse.On);
    }

}
